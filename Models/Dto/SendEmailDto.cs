﻿namespace MyProject.Web.Models.Dto
{
    public class SendEmailDto
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string Password { get; set; }
    }
}
