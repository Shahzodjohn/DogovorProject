using Entity.DataTransfer_s;
using Entity.DataTransfer_s.MailRequestDTO;
using Entity.MailSettings;
using Entity.ResponseMessage;
using Interface.Interfaces;
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
        private readonly IUserRepository _userRepository;
        private readonly ICodeResetRepository _reset;

        public MailService(IOptions<MailSettings> options, IFormRepository formRepository, IUserRepository userRepository, ICodeResetRepository reset)
        {
            _settings = options.Value;
            _formRepository = formRepository;
            _userRepository = userRepository;
            _reset = reset;
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
        Response response = new Response();
        public async Task<string> SendEmailResetAsync(string ToEmail)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.Mail);
            email.To.Add(MailboxAddress.Parse(ToEmail));

            var builder = new BodyBuilder();
           
            var random = new Random();
            var randomNumber = random.Next(1000, 9999);
            var ToUser = email.To.ToString();
            // var userCode = await _context.DmUsers.FirstOrDefaultAsync(x=>x.Email == t)
            var compare = await _userRepository.GetUserbyEmail(ToUser);
            var UserCode = await _userRepository.GetUserCodeCompared(ToEmail);
            //if (UserCode == null)
            //    return response.ToLog("400", "Error! Email not found!");
            var date = DateTime.Now.AddHours(2);
            if (UserCode != null)
            {
                UserCode.RandomNumber = randomNumber.ToString();
            }
            else
            {
                var dataInsert = await _reset.Insert(randomNumber.ToString(), compare.Id, date);
            }
            email.Subject = "Восстановление пароля";
            builder.HtmlBody = "Ваш идентификатор доступа. Никому не сообщайте код, даже сотрудникам организации. Ваш код - " + randomNumber.ToString();
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_settings.Mail, _settings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            return "Ok || 200";
        }

    }
}
