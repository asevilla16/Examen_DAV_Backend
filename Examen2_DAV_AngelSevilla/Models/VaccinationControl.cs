using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Models
{
    public class VaccinationControl
    {
        [Key]
        public int id { get; set; }
        public DateTime VaccinationDate { get; set; }

        public int PacientId { get; set; }
        [ForeignKey("PacientId")]
        public Pacient Pacient { get; set; }

        public int VaccineId { get; set; }
        [ForeignKey("VaccineId")]
        public Vaccine Vaccine { get; set; }

        public int VaccinationCenterId { get; set; }
        [ForeignKey("VaccinationCenterId")]
        public VaccinationCenter VaccinationCenter { get; set; }
        public int Dose { get; set; }

    }
}
