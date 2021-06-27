using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IVaccineAppService
    {
        Task<IEnumerable<Vaccine>> GetVaccines();
        Task<ActionResult<Vaccine>> GetVaccine(int id);
        void AddVaccine(Vaccine vaccine);
        void UpdateVaccine(Vaccine vaccine);
        Task<string> DeleteVaccine(int id);
    }
}
