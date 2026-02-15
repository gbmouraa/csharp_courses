namespace MeuSiteEmMVC.Helpers
{
    public interface IEmail
    {
        Task<bool> Enviar(string email, string assunto, string mensagem);
    }
}
