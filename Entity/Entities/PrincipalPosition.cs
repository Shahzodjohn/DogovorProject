﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class PrincipalPosition
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
    }
}