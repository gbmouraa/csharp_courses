using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Helpers;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // variavél para extrair os métodos de Banco de dados
        private readonly BancoContext _bancoContext;

        // injeção do contexto do banco
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            // a variavél privada recebe a instância de bancoContext
            _bancoContext = bancoContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }

        public UsuarioModel? BuscarPorEmailELogin(string login, string email)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login == login && x.Email == email);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Erro ao atualizar usuario - usuario não encontrado na base de dados");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public void AlterarSenha(AlterarSenhaViewModel model)
        {
            UsuarioModel usuarioDB = ListarPorId(model.Id);

            if(usuarioDB == null)
            {
                throw new SystemException("Usuario não encontrado");
            }
            if (!usuarioDB.ValidarSenha(model.SenhaAtual))
            {
                throw new SystemException("Senha atual está incorreta");
            }

            usuarioDB.SetSenhaHash(model.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();       
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new SystemException("Houve um erro ao tentar excluir o contato");

            _bancoContext.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
