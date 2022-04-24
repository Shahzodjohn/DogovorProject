using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class PrincipalInfo
    {
        [Key]
        public int Id { get; set; }
        public int PrincipalPlaceId { get; set; }
        public int PrincipalPositionId { get; set; }
        public int PrincipalNameId { get; set; }
        public int PrincipalReasonId { get; set; }
        public int ReceiversAmount { get; set; }


        public virtual PrincipalPlace PrincipalPlace { get; set; }
        public virtual PrincipalPosition PrincipalPosition { get; set; }
        public virtual PrincipalName PrincipalName { get; set; }
        public virtual PrincipalReason PrincipalReason { get; set; }

    }
}
