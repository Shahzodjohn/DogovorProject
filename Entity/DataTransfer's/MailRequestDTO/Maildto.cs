﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransfer_s.MailRequestDTO
{
    public class Maildto
    {
        public string ToEmail { get; set; }
        public IFormFile file { get; set; }
        
    }
}