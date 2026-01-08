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

<<<<<<< HEAD

    public IActionResult Criar()
    {
=======
    public IActionResult Criar()
    { // essa view usa a model nos valores dos campos
        // porém como aqui não é passado uma model os campos começam vazios
>>>>>>> 0fbf9d2c00a1f3dc0f40c0be2ba4f364a12a1e11
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
<<<<<<< HEAD
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
    public IActionResult Editar(UsuarioSemSenhaModel usuario)
    {
        if (ModelState.IsValid)
        {
            _usuarioRepositorio.Atualizar(usuario);
            TempData["MensagemSucesso"] = "Usuário Atualizado com Sucesso";
            return RedirectToAction("Index");
        }

        return View(usuario);
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
=======
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
>>>>>>> 0fbf9d2c00a1f3dc0f40c0be2ba4f364a12a1e11
}
