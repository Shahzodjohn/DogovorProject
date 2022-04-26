using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Entity.DataTransfer_s.MailRequestDTO;
using Entity.MailSettings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Service.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(Maildto mailRequest,string FilePath)
        {
            var file = GetFileByPath(FilePath);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Mail);    
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            var builder = new BodyBuilder();
            email.Subject = "Ваколатнома";
            if (file != null)
            {
                byte[] filebytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    filebytes = ms.ToArray();
                }
                builder.Attachments.Add(email.Subject, filebytes);
            }
            builder.HtmlBody = "Документ" /*+ randomNumber.ToString()*/;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_settings.Mail, _settings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            //builder.HtmlBody = mailRequest.Body;
            //  builder.HtmlBody = string.Join(", ", gtin); // вот так вот надо делать Tostring(); //body
        }
        private Stream GetFileByPath(string Path)
        {
            MemoryStream ms = new MemoryStream();
            string[] DocxFile = Directory.GetFiles($"{Path}", "*.docx");
            for (int fileLength = 0; fileLength < DocxFile.Length; fileLength++)
            {
                string filePath = DocxFile[fileLength];
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                 ms = new MemoryStream(bytes);
            }
            return ms;
        }
    }
}
