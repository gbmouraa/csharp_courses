using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MeuSiteEmMVC.Helpers
{
    public class Email : IEmail
    {
        private readonly IConfiguration _config;

        public Email(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<bool> Enviar(string emailDestinatario, string assunto, string mensagem)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(_config["Email:Name"]));
                email.To.Add(MailboxAddress.Parse(emailDestinatario));
                email.Subject = assunto;

                email.Body = new TextPart("html")
                {
                    Text = mensagem
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    _config["Email:SmtpHost"],
                    587,
                    SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(
                    _config["Email:SmtpUser"],
                    _config["Email:SmtpPass"]);

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
