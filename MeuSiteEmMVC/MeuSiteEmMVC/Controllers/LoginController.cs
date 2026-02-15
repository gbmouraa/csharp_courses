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
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sesssao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //  se usuário estiver logado redireciona para home
            if (_sesssao.BuscarSessaoDoUsuario() != null)
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

                    // adicionar erros caso login ou senha errados

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

            return RedirectToAction("Index", "Login");
        }

        public ActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RedefinirSenha(RedefinirSenhaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(model.Login, model.Email);


                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        var  emailEnviado = await _email.Enviar(usuario.Email, "Sistema de Contatos - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos um link para redefinição de senha para o seu email";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail, tente novamente";
                        }

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Parece que os dados estão incorretos, verifique e tente novamente";
                }

                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao redefinir senha: {ex}";
                return RedirectToAction("Index");
            }
        }
    }
}
