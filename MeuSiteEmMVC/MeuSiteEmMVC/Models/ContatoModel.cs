using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeuSiteEmMVC.Models
{
    public class ContatoModel
    {
        //public ContatoModel(string nome, string email, string telefone)
        //{
        //    Nome = nome;
        //    Email = email;
        //    Telefone = telefone;
        //}

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
