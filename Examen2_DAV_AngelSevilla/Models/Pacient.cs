using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Models
{
    public class Pacient
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string identity { get; set; }
        public string Carnet { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
