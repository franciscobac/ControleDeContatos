using System.Net;
using System.Net.Mail;

public class Email : IEmail
{
    private readonly IConfiguration _configuration;

    public Email(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool Enviar(string email, string assunto, string mensagem)
    {
        try
        {
            /*
            string host = _configuration.GetValue<string>("SMTP:Host");
            string nome = _configuration.GetValue<string>("SMTP:Nome");
            string username = _configuration.GetValue<string>("SMTP:UserName");
            string senha = _configuration.GetValue<string>("SMTP:Senha");
            int porta = _configuration.GetValue<int>("SMTP:Host");
            */
            string host = "smtp-mail.outlook.com";
            string nome = "Sistema de Contatos";
            string username = "franciscobac@hotmail.com";
            string senha = "Bl1ndGu4rd14n@88";
            int porta = 587;

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(username, nome)
            };

            mail.To.Add(email);
            mail.Subject = assunto;
            mail.Body = mensagem;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(host, porta))
            {
                smtp.Credentials = new NetworkCredential(username, senha);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
        }
        catch (System.Exception)
        {
            // Gravar log de erro ao enviar e-mail

            return false;
        }
    }
}
