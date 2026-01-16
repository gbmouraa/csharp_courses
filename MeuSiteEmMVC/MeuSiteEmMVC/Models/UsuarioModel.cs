using MeuSiteEmMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models;

public class UsuarioModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo login é obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [EmailAddress(ErrorMessage = "Insira um email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Informe o perfil do usuário")]
    public PerfilEnum? Perfil { get; set; }

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public bool ValidarSenha(string senha)
    {
        return Senha == senha;
    }
}
