using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductRentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductRentApp.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index(ListedProductsPending prd)
        {
            ViewBag.adminid = HttpContext.Session.GetString("adminid");
            ViewBag.adminname = HttpContext.Session.GetString("adminname");
            ViewBag.adminloc = HttpContext.Session.GetString("adminloc");

            List<ListedProductsPending> productpending = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44341/api/ListedProductsPendings");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productpending = JsonConvert.DeserializeObject<List<ListedProductsPending>>(EmpResponse);

                }
               
            }
            int count = 0;
            int approved = 0;
            foreach(var item in productpending)
            {
                if (item.PostStatus == "Pending")
                {
                    count += 1;
                }
                else
                {
                    approved += 1;
                }
            }
            ViewBag.pending = count;
            ViewBag.approved = approved;
            return View(prd);
        }
        public async Task<IActionResult> ADRequests()
        {
            List<ListedProductsPending> productpending = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44341/api/ListedProductsPendings");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productpending = JsonConvert.DeserializeObject<List<ListedProductsPending>>(EmpResponse);

                }
                
            }
            return View(productpending);
        }
           
            public IActionResult ReturnRequest()
            {
                return View();
            }
            public IActionResult ListedProd()
            {
                return View();
            }
        public async Task<ListedProductsPending> getprodpending(int id)
        {
            ListedProductsPending prd = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44341/api/ListedProductsPendings/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prd = JsonConvert.DeserializeObject<ListedProductsPending>(apiResponse);
                }
            }
            return prd;
        }
        public async Task<IActionResult> approved(int id)
        {
            ListedProductsPending prd = new();
            ListedProductsPending afterupdate = new();
            ListedProduct newlisting = new();
            ListedProduct afterlisting = new();
            ViewBag.userid = HttpContext.Session.GetString("uid");
            prd = await getprodpending(id);
            prd.PostStatus = "Approved";
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(prd), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44341/api/ListedProductsPendings/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            afterupdate = await getprodpending(id);
            newlisting.ProductCategory = afterupdate.ProductCategory;
            newlisting.ProductType = afterupdate.ProductType;
            newlisting.Brand = afterupdate.Brand;
            newlisting.Model = afterupdate.Model;
            newlisting.RentalDuration = afterupdate.RentalDuration;
            newlisting.RentalFee = afterupdate.RentalFee;
            newlisting.City = afterupdate.City;
            newlisting.Pincode = afterupdate.Pincode;
            newlisting.ContactNumber = afterupdate.ContactNumber;
            newlisting.ProductDescription = afterupdate.ProductDescription;
            newlisting.ProductImage = afterupdate.ProductImage;
            newlisting.UserId = afterupdate.UserId;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newlisting), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44341/api/ListedProducts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    afterlisting = JsonConvert.DeserializeObject<ListedProduct>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> reject(int id)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44341/api/ListedProductsPendings/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("ADRequests","Admin");
        }
     }
}
