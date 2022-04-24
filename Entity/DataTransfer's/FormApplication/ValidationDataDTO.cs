using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s.FormApplication
{
    public class ValidationDataDTO
    {
        public int OrderId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntill { get; set; }
    }
}
