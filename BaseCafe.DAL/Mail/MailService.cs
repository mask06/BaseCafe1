using BaseCafe.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public MailService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task SendConfimationAsync(AppUser user, string code)
        {
            var mailContent = new StringBuilder();
            mailContent.Append(@$"Merhaba<b>{user.UserName}</b>,Uygulamamıza Hoşgeldin");
            mailContent.Append("Giriş Yapmak için son bir adım kaldı .LÜtfen Mailinizi onaylayınız");
            mailContent.AppendLine(@$"<a href='http://localhost:5167/home/deneme?email={user.Email}&code={code}'>Onayla</a>");
            await SendMailAsync(user.Email, "Onaylama Işlemi", mailContent.ToString());
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
