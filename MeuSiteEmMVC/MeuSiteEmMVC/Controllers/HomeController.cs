using System.Diagnostics;
using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class HomeController : Controller
    {

        private static Botao _botao = new Botao();
        //public HomeController()
        //{
            
        //}

        public IActionResult Index()
        {
            // para consumir os dados de uma model é preciso passa-los para a view
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            _botao.Add();
            return Json(new { total = _botao.Total });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
