using Microsoft.AspNetCore.Mvc;
using MyProject.Web.Models.Dto;
using MyProject.Web.Utility;

namespace MyProject.Web.Controllers
{
    public class SendEmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public SendEmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            EmailDto email = new EmailDto()
            {
                To = "Thanhdyso1@gmail.com",
                Subject = "Test",
                Body = "Test"
            };

            SendEmailDto sendEmail = new SendEmailDto()
            {
                SmtpServer = _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                Port = _configuration.GetValue<int>("EmailSettings:Port"),
                SenderEmail = _configuration.GetValue<string>("EmailSettings:SenderEmail"),
                SenderName = _configuration.GetValue<string>("EmailSettings:SenderName"),
                Password = _configuration.GetValue<string>("EmailSettings:Password")
            };
            await SolutionModule.SendEmailAsync(email, sendEmail);
            return RedirectToAction("Index", "Product");
        }
    }
}
