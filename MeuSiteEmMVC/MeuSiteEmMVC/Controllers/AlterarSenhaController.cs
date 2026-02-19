using MeuSiteEmMVC.Helpers;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alterar(AlterarSenhaViewModel model)
        {
            if (!ModelState.IsValid) return View("Index", model);

            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                model.Id = usuarioLogado.Id;

                if (usuarioLogado != null)
                {
                    _usuarioRepositorio.AlterarSenha(model);
                    TempData["Sucesso"] = "Senha alterada com sucesso";
                    return View("Index","Home");
                }
                return View("Index", model);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Não foi possivel alterar sua senha no momento, tente novamente mais tarde";
                return RedirectToAction("Index");
            }
        }
    }
}
