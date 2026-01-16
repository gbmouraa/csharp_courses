using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public interface IUsuarioRepositorio
{
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel BuscarPorLogin(string login);
    List<UsuarioModel> BuscarTodos();
    UsuarioModel ListarPorId(int id);
    UsuarioModel Atualizar(UsuarioModel usuario);
    bool Apagar(int id);
}
