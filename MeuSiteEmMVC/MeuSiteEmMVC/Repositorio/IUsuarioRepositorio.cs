using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio;

public interface IUsuarioRepositorio
{
    UsuarioModel Adicionar(UsuarioModel usuario);
    List<UsuarioModel> BuscarTodos();
    UsuarioModel ListarPorId(int id);
    UsuarioSemSenhaModel Atualizar(UsuarioSemSenhaModel usuario);
    bool Apagar(int id);
}
