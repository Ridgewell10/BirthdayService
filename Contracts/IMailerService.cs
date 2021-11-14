using System.Net.Mail;

namespace Contracts
{
    public  interface IMailerService
    {
        void SendMail(MailMessage mailMessage);

    }
}
