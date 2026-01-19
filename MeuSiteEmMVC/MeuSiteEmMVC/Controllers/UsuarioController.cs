using MeuSiteEmMVC.Filters;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers;

[FiltroAdmin]
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
            if (ModelState.IsValid)
            {
                usuario = _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário Adicionado com sucesso";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = "Erro ao adicionar usuário";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Editar(int id)
    {
        UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
        return View(usuario);
    }


    [HttpPost]
    public IActionResult Editar(UsuarioModel usuario)
    {
        try
        {
            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                UsuarioModel usuarioAtualizado = new UsuarioModel()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Email = usuario.Email,
                    Perfil = usuario.Perfil
                };

                usuarioAtualizado = _usuarioRepositorio.Atualizar(usuario);
                TempData["MensagemSucesso"] = "Usuário Atualizado com Sucesso";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = "Não conseguimos atulizar o usuáiro";
            return View("Index");
        }
    }

    public IActionResult ApagarUsuario(int id)
    {
        var usuario = _usuarioRepositorio.ListarPorId(id);
        if (usuario == null)
        {
            TempData["MensagemErro"] = "Usuário não encontrado";
            return RedirectToAction("Index");
        }

        return View(usuario);

    }

    public IActionResult ApagarConfirma(int id)
    {
        bool sucecess = _usuarioRepositorio.Apagar(id);

        if (sucecess)
        {
            TempData["MensagemSucesso"] = "Usuário removido com sucesso";
        }

        return RedirectToAction("Index");
    }
}
