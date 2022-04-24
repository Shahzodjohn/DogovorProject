using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public int cityId { get; set; }
        public DateTime DateOfIssue { get; set; }




        public virtual City City { get; set; }
    }
}
