using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public IActionResult Index()
    {
        List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
        return View(usuarios);
    }

    public IActionResult Criar()
    { // essa view usa a model nos valores dos campos
        // porém como aqui não é passado uma model os campos começam vazios
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid) // caso a model seja válida é adicionada e retorna para Index com msg de sucesso
            {
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = $"O usuário {usuario.Nome} foi criado com sucesso";
                return RedirectToAction("Index");
            }

            return View(usuario); // caso n passe na validação retorna a view Criar com os dados utuais da model
        }
        catch (Exception ex)
        {
            TempData["MensagemError"] = "Erro ao cadastrar usuário";
            return RedirectToAction("Index");
        }
    }
}
