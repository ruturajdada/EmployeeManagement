using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_Challange.Models;
using System.Diagnostics;

namespace MVC_CRUD_Challange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MVC_CRUD_DBContext dBContext;

        public HomeController(ILogger<HomeController> logger, MVC_CRUD_DBContext _DBContext)
        {
            _logger = logger;
            dBContext = _DBContext;
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