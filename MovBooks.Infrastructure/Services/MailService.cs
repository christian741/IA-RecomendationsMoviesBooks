using System.Net;
using System.Net.Mail;
using MovBooks.Infrastructure.Interfaces;

namespace MovBooks.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress("noreply@movbooks.co", "MovBooks"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };
            msg.To.Add(to);

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("movbooks222@gmail.com", "movbooks12345"),
                EnableSsl = true
            };
            client.Send(msg);
        }
    }
}
