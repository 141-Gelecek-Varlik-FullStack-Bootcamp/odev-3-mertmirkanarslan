using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SemtPazari.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SemtPazari.Controllers
{
    //Projenin ana iskeleti düşünülerek oluşturuldu. Ödevin konusu olmadığı için kullanılmaya ihtiyaç duyulmadı. Aynı şekilde Core katmanı da oluşturuldu fakat
    //proje özelinde Core katmana da ihtiyaç duyulmadı. 
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
