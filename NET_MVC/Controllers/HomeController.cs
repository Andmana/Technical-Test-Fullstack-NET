using Microsoft.AspNetCore.Mvc;
using NET_Models;
using NET_MVC.Models;
using NET_MVC.Services;
using System.Diagnostics;
using System.Xml.Linq;

namespace NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly CompaniesService service;

        public HomeController(ILogger<HomeController> _logger, CompaniesService _service)
        {
            logger = _logger;
            service = _service;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CompanyRegistration(CompanyRegistrationRequest model)
        {
            var response = await service.CompanyRegistrationAsync(model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                logger.LogInformation("/n/n/------------------/n");
                logger.LogInformation(result);
                return Content(result, "application/json");
            }
            else
            {
                
                var error = await response.Content.ReadAsStringAsync();
                logger.LogInformation("/n/n/------------------/n");
                logger.LogInformation(error);
                //return StatusCode((int)response.StatusCode, error);
                return new ContentResult
                {
                    Content = error, // JSON string
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
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
