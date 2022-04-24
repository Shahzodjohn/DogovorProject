using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class FormToFill
    {
        public int Id { get; set; }
        public int? documentId { get; set; }
        public int? principalInfoId { get; set; }
        //public int? receiversAmount { get; set; }
        public int? receiversInfoId { get; set; }
        public int? purposeId { get; set; }
        public DateTime? validFrom { get; set; }
        public DateTime? validUntill { get; set; }



        public virtual PrincipalInfo PrincipalInfo { get; set; }
        public virtual ReceiverInfo ReceiversInfo { get; set; }
        public virtual Purpose Purpose { get; set; }
    }
}
