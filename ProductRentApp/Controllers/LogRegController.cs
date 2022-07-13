using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductRentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace ProductRentApp.Controllers
{
    public class LogRegController : Controller
    {
      
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.SetString("adminid", "");
            HttpContext.Session.SetString("username", "");
            return View("login");
        }
        public async Task<ActionResult> CheckLogin(string email, string password)
        {
            UserDetail prd = new UserDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44366/api/UserDetail?gmail=" + email))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prd = JsonConvert.DeserializeObject<UserDetail>(apiResponse);
                }
            }
            if (prd == null)
            {
                return View("Login");
            }
            else if(prd.Gmail=="admin@rentalmedia.com" && prd.Password == "admin")
            {
                HttpContext.Session.SetString("adminid", prd.UserName);
                HttpContext.Session.SetString("adminname", prd.Gmail);
                HttpContext.Session.SetString("adminloc", prd.Location);
                return RedirectToAction("Index", "Admin");
            }
            else if (prd.Password == password)
            {
                HttpContext.Session.SetString("username", prd.UserName);
                HttpContext.Session.SetString("uid",prd.UserId);
                HttpContext.Session.SetString("ulocation", prd.Location);
                HttpContext.Session.SetString("ugmail", prd.Gmail);
                return RedirectToAction("Main","Home");
            }
            else
            {
                return View("Login");
            }
        }
        public async Task<IActionResult> UserDetails()
        {
            List<UserDetail> UserInfo = new List<UserDetail>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44366/api/UserDetail/Getallusers");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    UserInfo = JsonConvert.DeserializeObject<List<UserDetail>>(UserResponse);

                }
                //returning the employee list to view  
                return RedirectToAction("Login","LogReg");
            }

        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserDetail ud)
        {
            UserDetail Detail = new();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ud), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44366/api/UserDetail", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Detail = JsonConvert.DeserializeObject<UserDetail>(apiResponse);

                }
            }
            return RedirectToAction("Login", "LogReg");
        }
    }
}
