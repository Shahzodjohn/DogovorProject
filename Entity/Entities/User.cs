using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
    }
}
