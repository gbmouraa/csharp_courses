using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public interface IContatoRepositorio
{
    ContatoModel Adicionar(ContatoModel contato);
    List<ContatoModel> BuscarTodos();
}
