using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Digite seu login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

    }
}
