using JuegoBingoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JuegoBingoMVC.Controllers
{
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

        /*public IActionResult Privacy()
        {
            return View();
        }*/

        public IActionResult New()
        {
            Partida miPartida = new(4);

            return View(miPartida);
        }

        /*public IActionResult New(string user)
        {

            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}