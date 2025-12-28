using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        // variavél para extrair os métodos de Banco context
        private readonly BancoContext _bancoContext;

        // injeção do contexto do banco
        public ContatoRepositorio(BancoContext bancoContext) 
        {
            // a variavél privada recebe a instância de bancoContext
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            // adiconar um contato ao banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

    }
}
