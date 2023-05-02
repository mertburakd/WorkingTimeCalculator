using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBUI.Depencency;
using WEBUI.Models;
using System.Diagnostics;
using System;
using Microsoft.Extensions.Hosting;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index(WorkPerModel result)
        {
            //var process = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = "docker",
            //        Arguments = "build -t testing:0.1 .",
            //        RedirectStandardOutput = true,
            //        UseShellExecute = false,
            //        CreateNoWindow = true,
            //        WorkingDirectory = "C:\\Users\\MERSUS\\Documents\\GitHub\\WorkingTimeCalculator\\SureHesaplayici\\WEBUI\\wwwroot\\carrefoursa-codeandmorecms"
            //    }
            //};
            //process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            //process.WaitForExit();

            //return Content(output);


            //ProcessStartInfo _processStartInfo = new ProcessStartInfo();

            //_processStartInfo.WorkingDirectory = "C:\\Users\\MERSUS\\Documents\\GitHub\\WorkingTimeCalculator\\SureHesaplayici\\WEBUI\\wwwroot\\carrefoursa-codeandmorecms\\CodeAndMoreNuget";
            ////_processStartInfo.CreateNoWindow = true;
            //Process myProcess = Process.Start(_processStartInfo);
            //myProcess.StartInfo.FileName = "C:\\WINDOWS\\system32\\cmd.exe";
            //myProcess.StartInfo.Arguments = "/c dir";
            //myProcess.StartInfo.UseShellExecute = true;
            //myProcess.Start();
            //string output = myProcess.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);

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