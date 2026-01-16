using Microsoft.AspNetCore.Mvc;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using MeuSiteEmMVC.Helpers;

namespace MeuSiteEmMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sesssao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sesssao = sessao;
        }

        public IActionResult Index()
        {
            //  se usuário estiver logado redireciona para home
            if(_sesssao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginData.Login);

                    if (usuario != null)
                    {
                        if (usuario.ValidarSenha(loginData.Senha))
                        {
                            _sesssao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(loginData.Senha), "Senha incorreta");
                            return View("Index", loginData);
                        }
                    }
                }

                return View("Index", loginData);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao fazer login: {ex}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _sesssao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index","Login");
        }
    }
}
