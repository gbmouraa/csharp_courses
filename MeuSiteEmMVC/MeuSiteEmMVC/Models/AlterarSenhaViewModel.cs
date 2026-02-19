using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class AlterarSenhaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a senha")]
        public string SenhaAtual { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare("NovaSenha", ErrorMessage = "A senhas não correspondem")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
