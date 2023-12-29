using APIBingo.Services.Notification;
using System.Net.Mail;
using System.Net;

namespace APIBingo.Services
{
    public class EMailSenderService
    {
        private readonly IEMailNotification _eMailNotification;


        public EMailSenderService(IEMailNotification eMailNotification) => _eMailNotification = eMailNotification;


        public void SendEMail(string toSend, string subject, string body, bool isBodyHtml)
        {
            using MailMessage message = _eMailNotification.CreateMessage();
            message.To.Add(toSend);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;

            using SmtpClient smtpClient = _eMailNotification.CreateClient();
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            smtpClient.Send(message);
        }
    }
}