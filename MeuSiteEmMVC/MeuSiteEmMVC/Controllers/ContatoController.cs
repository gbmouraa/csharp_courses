using Microsoft.AspNetCore.Mvc;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Repositorio;

namespace MeuSiteEmMVC.Controllers;

public class ContatoController : Controller
{
    // campo (guarda um objeto que implementa a interface)
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

    [HttpPost] // posso criar um método de mesmo nome porém o método HTTP precisa ser diferente
    public IActionResult Criar(ContatoModel contato)
    {
        _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");
    }

    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
        _contatoRepositorio.Atualizar(contato);
        return RedirectToAction("Index");
    }

    public IActionResult Apagar()
    {
        return View();
    }

}
