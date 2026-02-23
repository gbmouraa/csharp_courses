using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public interface IContatoRepositorio
{
    ContatoModel Adicionar(ContatoModel contato);
    List<ContatoModel> BuscarTodos(int UsuarioId);
    ContatoModel ListarPorId(int id);
    ContatoModel Atualizar(ContatoModel contato);
    bool Apagar(int id);
}
