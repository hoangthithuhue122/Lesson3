using System.Diagnostics;
using HtthLesson06.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtthLesson06.Controllers
{
    public class HtthHomeController : Controller
    {
        private readonly ILogger<HtthHomeController> _logger;

        public HtthHomeController(ILogger<HtthHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HtthIndex()
        {
            return View();
        }

        public IActionResult HtthPrivacy()
        {
            return View();
        }

        public IActionResult HtthAbout()
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
