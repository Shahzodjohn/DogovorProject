using Entity.DataTransfer_s.MailRequestDTO;
using Entity.MailSettings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using Repository;

namespace Service.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;
        private readonly IFormRepository _formRepository;

        public MailService(IOptions<MailSettings> options, IFormRepository formRepository)
        {
            _settings = options.Value;
            _formRepository = formRepository;
        }
        public async Task SendEmailAsync(Maildto mailRequest, string Path)
        {
            var OrderInfo = await _formRepository.OrderInfo(mailRequest.OrderId);
            var UserPassport = OrderInfo.ReceiversInfo.PassportNumber;
            var UserDocumentNumber = OrderInfo.Document.DocumentNumber;
            var newPath = Path + @"\User " + UserPassport;
            string[] FileCheck = Directory.GetFiles(newPath, "*.docx");
            foreach (var fileCheck in FileCheck)
            {
                if (fileCheck.Contains(UserDocumentNumber))
                    newPath = fileCheck;
            }
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Mail);    
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            var builder = new BodyBuilder();
            email.Subject = "Ваколатнома";
            builder.Attachments.Add(newPath);
            builder.HtmlBody = "Документ";
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_settings.Mail, _settings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
