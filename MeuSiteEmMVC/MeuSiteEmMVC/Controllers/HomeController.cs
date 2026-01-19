using System.Diagnostics;
using MeuSiteEmMVC.Filters;
using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    [FiltroLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // para consumir os dados de uma model é preciso passa-los para a view
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
