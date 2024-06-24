namespace FinalProject.Business.Services.Abstarct;

public interface IEmailService
{
    void SendEmail(string toEmail, string subject, string body);
}
