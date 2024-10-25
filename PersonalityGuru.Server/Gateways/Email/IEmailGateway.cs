namespace PersonalityGuru.Server.Gateways.Email
{
    public interface IEmailGateway
    {
        Task SendEmailAsync(string toEmail, string toName, string subject, string message);
    }
}
