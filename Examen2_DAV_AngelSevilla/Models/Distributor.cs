﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Models
{
    public class Distributor
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

    }
}
