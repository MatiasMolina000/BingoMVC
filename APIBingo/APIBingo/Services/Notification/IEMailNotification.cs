using System.Net.Mail;

namespace APIBingo.Services.Notification
{
    public interface IEMailNotification
    {
        MailMessage CreateMessage();
        SmtpClient CreateClient();
    }
}
