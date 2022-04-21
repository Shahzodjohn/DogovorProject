using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class UserDepartmentDTO
    {
        public int UserId { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
