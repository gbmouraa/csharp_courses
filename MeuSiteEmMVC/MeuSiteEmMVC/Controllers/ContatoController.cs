using Microsoft.AspNetCore.Mvc;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Repositorio;

namespace MeuSiteEmMVC.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }

    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar()
    {
        return View();
    }

    public IActionResult Apagar()
    {
        return View();
    }

    [HttpPost] // posso criar um método de mesmo nome porém o método HTTP precisa ser diferente
    public IActionResult Criar(ContatoModel contato)
    {
        _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");
    }
}
