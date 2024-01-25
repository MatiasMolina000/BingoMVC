using System.Net;
using System.Net.Mail;

namespace APIBingo.Services.Notification
{
    public class EMailNotification : IEMailNotification
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtppUsername;
        private readonly string _smtpPassword;
        private readonly string _smtpAddress;

        public EMailNotification(IConfiguration iConfiguration)
        {
            _smtpServer = iConfiguration["Email:SmtpConfig:SmtpServer"];
            _smtpPort = int.Parse(iConfiguration["Email:SmtpConfig:SmtpPort"]);
            _smtppUsername = iConfiguration["Email:SmtpConfig:SmtpUsername"];
            _smtpPassword = iConfiguration["Email:SmtpConfig:SmtpPassword"];
            _smtpAddress = iConfiguration["Email:SmtpConfig:SmtpAddress"];
        }

        public MailMessage CreateMessage()
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(_smtpAddress, _smtppUsername)
            };

            return mailMessage;
        }

        public SmtpClient CreateClient()
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpAddress, _smtpPassword),
                EnableSsl = true,
            };

            return smtpClient;
        }
    }
}
