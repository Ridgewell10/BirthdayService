using Contracts;
using Entities;
using MailService;
using System.Threading.Tasks;

namespace API
{
    public class SendEmailNotification
    {
        private readonly IMailerService _emailService;
        public SendEmailNotification(EmailSender emailService)
        {
            _emailService = emailService;
        }

        public SendEmailNotification()
        {
            _emailService = new EmailSender();
        }

        public async Task<bool> SendNotificationAsync(EmployeeDto employee)
        {

            var message = new EmailMessage(new string[] { "ridglr@gmail.com" }, "It is your birthday today", "Happy Birthday "+ employee.name + " " + employee.lastname);
            await _emailService.SendEmailAsync(message);
            return true;
        }
    }
}
