using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IVaccinationControlAppService
    {
        Task<IEnumerable<VaccinationControl>> GetVaccinationControls();
        Task<ActionResult<VaccinationControl>> GetVaccinationControl(int id);
        void AddVaccinationControl(VaccinationControl vaccinationControl);
        void UpdateVaccinationControl(VaccinationControl vaccinationControl);
        Task<string> DeleteVaccinationControl(int id);
    }
}
