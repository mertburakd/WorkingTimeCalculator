using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBUI.Depencency;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(WorkPerModel result)
        {
            return View(result);
        }

        [HttpPost]
        public IActionResult Calculate(WorkPerModel workPerModel)
        {
            var MininuteData = workPerModel.WorkTimeMinute.Split(' ').Select(int.Parse).ToList();
            var result = Calculater.CalculateApp(MininuteData,workPerModel.Per8HourPayment);
            workPerModel.ResultFull= result;
            return RedirectToAction("Index","Home", workPerModel); 
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