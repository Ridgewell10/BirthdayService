using API.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;

namespace API.Controllers
{
    public class EmailController : Controller
    {

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailDto emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (var mailMessage = CreateEmailMessage(emailInfo))
                {
                    var mailService = new SendGridMailerService();

                    mailService.SendMail(mailMessage);

                    LogEmailStatus(emailInfo, EmailDto.STATUS_SUCCESS, EmailDto.STATUS_SUCCESS_MESSAGE);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                LogEmailStatus(emailInfo, EmailDto.STATUS_ERROR, ex.Message);

            }
        }
        private MailMessage CreateEmailMessage(EmailDto email)
        {
            var message = new MailMessage
            {
                From = new MailAddress("no-reply@outlook", "Birthday Notification"),
                Subject = email.Subject,
                IsBodyHtml = false,
                Body = email.Message
            };

            AddRecipients(email, message);

            return message;
        }

        private void AddRecipients(EmailDto email, MailMessage message)
        {


        }


        private void LogEmailStatus(EmailDto emailInfo, string status, string statusText)
        {
            using var dbContext = DataFactory.Default.GetDbContext<AvaDbContext>();
            EmailLog emailLog = new EmailLog()
            {
                Subject = emailInfo.Subject,
                Message = emailInfo.Message,
                SendTimeUtc = DateTimeOffset.Now.UtcDateTime,
                Status = status,
                StatusText = statusText
            };

            dbContext.Add(emailLog);
            dbContext.SaveChanges();
        }
    }
}
