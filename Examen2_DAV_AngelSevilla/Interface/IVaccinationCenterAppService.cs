using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IVaccinationCenterAppService
    {
        Task<IEnumerable<VaccinationCenter>> GetVaccinationCenters();
        Task<ActionResult<VaccinationCenter>> GetVaccinationCenter(int id);
        void AddVaccinationCenter(VaccinationCenter vaccinationCenter);
        void UpdateVaccinationCenter(VaccinationCenter vaccinationCenter);
        Task<string> DeleteVaccinationCenter(int id);
    }
}
