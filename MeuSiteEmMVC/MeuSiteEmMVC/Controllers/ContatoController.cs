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
        // verifica se os dados são válidos de acordo com o data annotation na model
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = $"{contato.Nome} foi adicionado com sucesso a sua lista de contatos.";
            }
            return RedirectToAction("Index");
        }
        catch (Exception err)
        {
            TempData["MensagemErro"] = $"Erro criar contato: {err.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato); // verificar se houve alterações
                TempData["MensagemSucesso"] = $"O contato {contato.Nome} foi alterado com sucesso";
                return RedirectToAction("Index");
            }
            return View(contato);
        }
        catch (Exception err)
        {
            TempData["MensagemErro"] = $"Erro ao editar contato";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Apagar(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult ApagarConfirma(int id)
    {
        try
        {
            bool apagado = _contatoRepositorio.Apagar(id);
            if (apagado)
            {
                TempData["MensagemSucesso"] = $"Contato removido com sucesso";
            }
            else
            {
                TempData["MensagemErro"] = $"Erro ao remover contato";
            }
            return RedirectToAction("Index");
        }
        catch (Exception err)
        {
            TempData["MensagemErro"] = $"Erro ao remover contato: {err.Message}";
            return RedirectToAction("Index");
        }
    }

}
