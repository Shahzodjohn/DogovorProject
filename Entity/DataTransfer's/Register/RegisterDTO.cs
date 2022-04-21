using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s
{
    public class RegisterDTO
    {
        public string EmailAddress { get; set; }
        public int DepartmentId { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
