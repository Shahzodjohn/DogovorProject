using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s.FormApplication
{
    public class ReceiversInfoDTO
    {
        public int OrderId { get; set; }
        public string ReceiversFullname { get; set; }
        public int СitizenshipId { get; set; }
        public int ReceiversPassportTypeId { get; set; }
        public string PassportNumber { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public DateTime PassportDateOfIssue { get; set; }
    }
}
