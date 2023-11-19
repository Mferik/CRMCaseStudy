using CRMAppCaseStudy.Models;
using CRMCaseStudy.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace CRMAppCaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7174")
};
        public async Task<IActionResult> Index()
        {
            using HttpResponseMessage response = await httpClient.GetAsync("api/customers");
        
                
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var customers = JsonSerializer.Deserialize<List<CustomerViewModel>>(jsonResponse);
            return View(customers);
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