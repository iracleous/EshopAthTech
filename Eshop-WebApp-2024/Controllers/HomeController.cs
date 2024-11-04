using Eshop_WebApp_2024.Models;
using EshopAthTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eshop_WebApp_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClientEshopWebAPI;


        public HomeController(ILogger<HomeController> logger, HttpClient httpClientEshopWebAPI)
        {
            _logger = logger;
            _httpClientEshopWebAPI = httpClientEshopWebAPI;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GivingData()
        {
            return View();
        }

        public IActionResult WebAPI(string mytext)
        {
          var response =   _httpClientEshopWebAPI.GetAsync("https://localhost:7191/WeatherForecast/product");
            HttpResponseMessage responseMessage = response.Result;
            ViewData["Data"] = responseMessage.Content.ReadAsStringAsync().Result;
            ViewData["mytext"] = mytext;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
