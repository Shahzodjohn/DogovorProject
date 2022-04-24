using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ReceiverInfo
    {
        public int Id { get; set; }
        public string ReceiversFullname { get; set; }
        public int ReceiversPassportTypeId { get; set; }
        public string PassportNumber { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public DateTime PassportDateOfIssue { get; set; }
        [ForeignKey(nameof(Citizenship))]
        public int СitizenshipId { get; set; }


        public virtual ReceiversPassportType ReceiversPassportType { get; set; }
        public virtual Citizenship Citizenship { get; set; }
    }
}
