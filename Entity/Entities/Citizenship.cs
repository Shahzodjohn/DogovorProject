using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Citizenship
    {
        public int Id { get; set; }
        public string CitizenOf { get; set; }
    }
}
