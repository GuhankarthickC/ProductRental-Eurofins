using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductRentApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductRentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Main(string category)
        {
            List<ListedProduct> ListedProd = new List<ListedProduct>();
            if (category == null)
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44341/api/ListedProducts");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UserResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        ListedProd = JsonConvert.DeserializeObject<List<ListedProduct>>(UserResponse);

                    }
                    
                }
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await httpClient.GetAsync("https://localhost:44341/api/ListedProducts/getbycategory" + category);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UserResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        ListedProd = JsonConvert.DeserializeObject<List<ListedProduct>>(UserResponse);
                    }
                }
            }
            return View(ListedProd);

        }
        public bool logincheck(string username)
        {
            if (username == null || username == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<IActionResult> kycsubmission(string kycdocument,string userkycproof,string userselfie)
        {
            UserVerification uv = new();
            UserVerification sv = new();
            uv.KycDocumentType = kycdocument;uv.UserKycProof = userkycproof;uv.UserSelfie = userselfie;
            uv.UserId= HttpContext.Session.GetString("uid");
            uv.KycStatus = "Pending";
            UserVerification user = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44366/api/UserVerifications/" + uv.UserId))
                {
                    if (((int)response.StatusCode)==200)
                    {
                        HttpContext.Session.SetString("kyc", "true");
                        
                    }
                    else
                    {
                        using (var httpsClient = new HttpClient())
                        {
                            StringContent content = new StringContent(JsonConvert.SerializeObject(uv), Encoding.UTF8, "application/json");

                            using (var responses = await httpsClient.PostAsync("https://localhost:44366/api/UserVerifications", content))
                            {
                                string apiResponse = await responses.Content.ReadAsStringAsync();
                                user = JsonConvert.DeserializeObject<UserVerification>(apiResponse);

                            }
                        }
                        
                    }
                    
                }
            }
            return RedirectToAction("Main", "Home");
        }
       
        public async Task<IActionResult> AddtoCart(int prod_id,string prod_uid,string adtitle,int rentalfee,string rentalduration,string proddesc,string adimage)
        {
            string username = HttpContext.Session.GetString("username");
            string userid = HttpContext.Session.GetString("uid");
            if (!logincheck(username))
            {
                return RedirectToAction("Login", "LogReg");
            }
            else
            {
                CartItem ct = new();
                ct.ListedProdId = prod_id;
                ct.ListedProdUid = prod_uid;
                ct.ItemStatus = "Requested to Rent";
                ct.UserId = userid;
                ct.AdTitle = adtitle;ct.RentalFee = rentalfee;ct.RentalDuration = rentalduration;ct.ProductDescription = proddesc;ct.ProductImg = adimage;
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(ct), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44330/api/CartItems", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                
                return RedirectToAction("CartItems","Home");
            }
            
        }
        public async Task<IActionResult> Orders(int cartid,string prodimg,string prodadtitle,string proddesc,int rentalfee,string rentaldur,int cart)
        {
            OrderDetail od = new();
            od.OrderStatus = "Order Placed";
            od.UserId = HttpContext.Session.GetString("uid");
            od.ProductId = cartid;
            od.ProductImage = prodimg;od.ProductAdtitle = prodadtitle;od.ProductDescription = proddesc;od.RentalFee = rentalfee;od.RentalDuration = rentaldur;od.OrderDate = DateTime.Now.ToShortDateString();od.OrderTime = DateTime.Now.ToShortTimeString();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(od), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44330/api/OrderDetails", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44330/api/CartItems/" + cart))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CartItems","Home");
        }
        public async Task<IActionResult> MyOrders()
        {
            string userid = HttpContext.Session.GetString("uid");
            List<OrderDetail> prd = new();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                //Define request data format  
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await httpClient.GetAsync("https://localhost:44330/api/OrderDetails/UserID" + userid);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    prd = JsonConvert.DeserializeObject<List<OrderDetail>>(UserResponse);
                }
            }
            
            
            return View(prd);
        }
        public async Task<IActionResult> DeleteCartItem(int cartid)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44330/api/CartItems/" + cartid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CartItems", "Home");
        }
        public async Task<IActionResult> CartItems()
        {
            List<CartItem> prd = new();
            string userid = HttpContext.Session.GetString("uid");
            using (var httpClient = new HttpClient())
            {
                        httpClient.DefaultRequestHeaders.Clear();
                        //Define request data format  
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await httpClient.GetAsync("https://localhost:44330/api/CartItems/Get" + userid);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UserResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            prd = JsonConvert.DeserializeObject<List<CartItem>>(UserResponse);
                        }
            }
            
            return View(prd);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
