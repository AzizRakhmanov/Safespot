using SendGrid;
using SendGrid.Helpers.Mail;

namespace Safespot.Service.Services.EmailService
{
    public class SendGridEmailSender
    {
        private readonly string apiKey = "your-sendgrid-api-key"; // Replace with your SendGrid API Key

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("zzrxmnv1002@gmail.com", "Rakhmanov Aziz"); // Replace with your email and name
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            try
            {
                var response = await client.SendEmailAsync(msg);
                Console.WriteLine($"Email sent. Status Code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
