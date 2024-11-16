namespace Safespot.Service.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string email, string subject, string body)
        {
            var emailSender = new SendGridEmailSender();
            string toEmail = "recipient@example.com"; // Replace with the recipient's email
            subject = "Test Email";
            string plainTextContent = "This is a test email sent using SendGrid.";
            string htmlContent = "<strong>This is a test email sent using SendGrid.</strong>";

            await emailSender.SendEmailAsync(toEmail, subject, plainTextContent, htmlContent);
        }
    }
}
