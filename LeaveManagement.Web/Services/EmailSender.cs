using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _fromEmail;

        public EmailSender()
        {

        }

        public EmailSender(string smtpServer, int smtpPort, string fromEmail)
        {
            this._smtpServer = smtpServer;
            this._smtpPort = smtpPort;
            this._fromEmail = fromEmail;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //we are now building out a mail message
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            //specify who the message is going to
            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(_smtpServer, _smtpPort);
            client.Send(message);

            return Task.CompletedTask;
        }
    }
}
