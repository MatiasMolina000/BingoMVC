using APIBingo.Services.Notification;

namespace APIBingo.Services
{
    public class EMailNotificationService
    {
        private readonly IEMailNotification _eMailNotification;


        public EMailNotificationService(IEMailNotification eMailNotification) => _eMailNotification = eMailNotification;


        public void ValidationMail(string toSend, string codeValidation)
        {
            EMailSenderService validationEMail = new(_eMailNotification);

            string subject = "Email Validation";
            
            //Add html message with the validatin code.
            string body = codeValidation;

            validationEMail.SendEMail(toSend, subject, body, true);
        }
    }
}