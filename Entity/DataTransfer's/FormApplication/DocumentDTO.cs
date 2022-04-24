using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s.FormApplication
{
    public class DocumentDTO
    {
        public string DocumentNumber { get; set; }
        public int cityId { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
