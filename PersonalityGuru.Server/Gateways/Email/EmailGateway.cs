using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace PersonalityGuru.Server.Gateways.Email
{
    public class EmailGateway : IEmailGateway
    {
        private readonly MailSettings mailSettings;
        private readonly bool isEnabled;

        public EmailGateway(IOptions<MailSettings> options)
        {
            mailSettings = options.Value;
            isEnabled = !String.IsNullOrEmpty(mailSettings.EmailId);
        }

        public async Task SendEmailAsync(string toEmail, string toName, string subject, string message)
        {
            if (!isEnabled) return;
            
            using var smtpClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(mailSettings.EmailId, mailSettings.Password);

            using var mailMessage = new MailMessage(
                from: new MailAddress(mailSettings.EmailId, mailSettings.Name),
                to: new MailAddress(toEmail, toName)
            );

            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            mailMessage.CC.Add(mailSettings.CopyToEmail);

            try {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Email sent to {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
