using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Models
{
    public class Vaccine
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int idDistributor { get; set; }
        [ForeignKey("idDistributor")]
        public Distributor Distributor { get; set; }
        public int DoseQuantity { get; set; }
    }
}
