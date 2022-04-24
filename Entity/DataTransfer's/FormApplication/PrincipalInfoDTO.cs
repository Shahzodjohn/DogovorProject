using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s.FormApplication
{
    public class PrincipalInfoDTO
    {
        public int OrderId { get; set; }
        public int PrincipalPlaceId { get; set; }
        public int PrincipalPositionId { get; set; }
        public int PrincipalNameId { get; set; }
        public int PrincipalReasonId { get; set; }
        public int ReceiversAmount { get; set; }
    }
}
