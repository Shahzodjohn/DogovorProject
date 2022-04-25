using Entity.DataTransfer_s.MailRequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(Maildto mailRequest);
    }
}
