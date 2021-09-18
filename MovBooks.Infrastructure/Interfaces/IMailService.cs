namespace MovBooks.Infrastructure.Interfaces
{
    public interface IMailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
