namespace Safespot.Service.Services.EmailService
{
    public interface IEmailService
    {
        public Task SendEmail(string email, string subject, string message);
    }
}
