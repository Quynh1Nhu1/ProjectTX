using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectTX.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ProjectTX.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {


            List<ProductModel> TestModeList = new List<ProductModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7064/api/Values"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TestModeList = JsonConvert.DeserializeObject<List<ProductModel>>(apiResponse).ToList();

                }
            }
            return View(TestModeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}