using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Net;
using System.Net.Mail;
using WebMSSQL.BA;

namespace WebMSSQL.Controllers
{
    public class HangFireController : Controller
    {
        public async Task<IActionResult> SendEmail(String email) {
           await SendEmailAsync(email, "Welcome");
            return new OkObjectResult(email);
        }

        public async Task SendEmailAsync(string email, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true; //тело сообщения в формате HTML
                mailMessage.From = new MailAddress("katevoronina128@gmail.com", "Hangfire"); //отправитель сообщения
                mailMessage.To.Add("katevoronina128@gmail.com"); //адресат сообщения
                mailMessage.Subject = "Сообщение от System.Net.Mail"; //тема сообщения
                mailMessage.Body = message; 
                mailMessage.Attachments.Add(new Attachment("... путь к файлу ...")); //добавить вложение к письму при необходимости

                using (System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com")) //используем сервера Google
                {
                    client.Credentials = new NetworkCredential("katevoronina128@gmail.com", "8962615kate"); //логин-пароль от аккаунта
                    client.Port = 587; //порт 587 либо 465
                    client.EnableSsl = true; //SSL обязательно

                    client.Send(mailMessage);
                }
            }
            catch (Exception e)
            {
            }
        }

    }

   
}
