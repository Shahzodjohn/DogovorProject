using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class PrincipalReason
    {
        [Key]
        public int Id { get; set; }
        public string ReasonType { get; set; }
    }
}
