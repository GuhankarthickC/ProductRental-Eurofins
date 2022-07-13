using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProductRentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductRentApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.username=HttpContext.Session.GetString("username");
            if (ViewBag.username == null || ViewBag.username=="")
            {
                return RedirectToAction("Login", "LogReg");
            }
            return View();
        }
        public async Task<IActionResult> ADCategories(string category)
        {
            List<ProductType> prd = new();
            List<ProdCity> prcity = new();
            ViewBag.category = category;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44320/api/ProductCategories/Catalog/" + category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prd = JsonConvert.DeserializeObject<List<ProductType>>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:44320/api/ProdCity"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prcity = JsonConvert.DeserializeObject<List<ProdCity>>(apiResponse);
                }
            }
            List<SelectListItem> l = new List<SelectListItem>();
            List<SelectListItem> lcity = new List<SelectListItem>();

            foreach (ProdCity pt in prcity)
            {
                lcity.Add(new SelectListItem { Text = pt.CityName, Value = pt.CityName });
            }
            ViewBag.cities = lcity;
            foreach (ProductType pt in prd)
            {
                l.Add(new SelectListItem { Text = pt.ProductType1, Value = pt.ProductType1 });
                string[] st = pt.ProductBrands.Split(",");
              
            }
            ViewBag.categorylist = l;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUser(ListedProductsPending lp)
        {
            ListedProductsPending prd = new();
            string userid= HttpContext.Session.GetString("uid");
            lp.UserId = userid;
            lp.PostStatus = "Pending";
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(lp), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44341/api/ListedProductsPendings", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prd = JsonConvert.DeserializeObject<ListedProductsPending>(apiResponse);

                }
            }
           
            return RedirectToAction("Index","Products");
        }
        
        public async Task<List<SelectListItem>> fetchbrands(string inp)
        {
            string apiResponse;
            List<SelectListItem> l = new List<SelectListItem>();
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44320/api/ProductCategories/Type/" + inp))
                {
                     apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            string[] sp = apiResponse.Split(",");
            foreach (string st in sp)
            {
                l.Add(new SelectListItem { Text = st, Value = st });
            }
            return l;
        }
        [HttpGet]
        public async Task<ActionResult> setvalue(string value)
        {
            var l=await fetchbrands(value);
            return Json(l); 
        }
    }
}
