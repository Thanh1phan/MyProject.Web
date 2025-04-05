using Humanizer;
using MimeKit;
using MyProject.Web.Models;
using MyProject.Web.Models.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;

namespace MyProject.Web.Utility
{
    public static class SolutionModule
    {
        public static T ConvertJsonToObject<T>(Object obj)
        {
            return JsonConvert.DeserializeObject<T>(Convert.ToString(obj));
        }
        public static bool CheckResponse(APIResponse response)
        {
            return response != null && response.IsSuccess;
        }


        public static async Task SendEmailAsync(EmailDto email,SendEmailDto sendEmailDto)
        {
            MailMessage message = new MailMessage(
               from: sendEmailDto.SenderEmail,
               to: email.To,
               subject: email.Subject,
               body: email.Body
           );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(sendEmailDto.SenderEmail));
            message.Sender = new MailAddress(sendEmailDto.SenderEmail);

            using (var client = new SmtpClient(sendEmailDto.SmtpServer))
            {
                try
                {
                    //Connect to SMTP Server (Ví dụ: Gmail SMTP)
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(sendEmailDto.SenderEmail, sendEmailDto.Password);
                    client.EnableSsl = true;
                    await client.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
