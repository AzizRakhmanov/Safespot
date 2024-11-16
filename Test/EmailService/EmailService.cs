using System.Net;
using System.Net.Mail;

namespace Safespot.Service.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string email, string subject, string message)
        {
            var mail = "arzrakhmanov@gmail.com";
            var pass = "whyareyoucallingme1002";

            var client = new SmtpClient("", 989)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pass)
            };

            await client.SendMailAsync(new MailMessage(
               from: mail,
               to: email,
               subject,
               message
               ));
        }
    }
}
