using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            var a = _configuration["smptSettings:Email"];
            var b = _configuration["smptSettings:Password"];
            var c = _configuration["smptSettings:Host"];

            mail.From = new MailAddress(a, "BaseCafe", Encoding.UTF8);

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(a, b);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = c;

            await smtp.SendMailAsync(mail);
        }
    }
}
