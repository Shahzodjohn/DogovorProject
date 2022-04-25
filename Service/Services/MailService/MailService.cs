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

        public async Task SendEmailAsync(Maildto mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Mail);    
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            var builder = new BodyBuilder();
            #region
            //if (mailRequest.Attechments != null)
            //{
            //    byte[] filebytes;
            //    foreach (var file in mailRequest.Attechments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                filebytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, filebytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            #endregion

            email.Subject = "Twój Identyfikator odzyskiwania hasła";
            if (mailRequest.file != null)
            {
                byte[] filebytes;
                using (var ms = new MemoryStream())
                {
                    mailRequest.file.CopyTo(ms);
                    filebytes = ms.ToArray();
                }
                builder.Attachments.Add(mailRequest.file.FileName, filebytes, ContentType.Parse(mailRequest.file.ContentType));
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
    }
}
