using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace PersonalityGuru.Server.Gateways.Email
{
    public class EmailGateway : IEmailGateway
    {
        private readonly MailSettings _mailSettings;

        public EmailGateway(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public async Task SendEmailAsync(string toEmail, string toName, string subject, string message)
        {
            using var smtpClient = new SmtpClient(_mailSettings.Host, _mailSettings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(_mailSettings.EmailId, _mailSettings.Password),
            };

            using var mailMessage = new MailMessage(
                from: new MailAddress(_mailSettings.EmailId, _mailSettings.Name),
                to: new MailAddress(toEmail, toName)
            );

            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
