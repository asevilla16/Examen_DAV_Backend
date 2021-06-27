using Examen2_DAV_AngelSevilla.DataContext;
using Examen2_DAV_AngelSevilla.Interface;
using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.AppService
{
    public class VaccinationCenterAppService : IVaccinationCenterAppService
    {
        private readonly VaccinationContext _vaccinationContext;

        public VaccinationCenterAppService(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }

        public async Task<IEnumerable<VaccinationCenter>> GetVaccinationCenters()
        {
            List<VaccinationCenter> vaccinationCenters = await _vaccinationContext.VaccinationCenters.ToListAsync();
            return vaccinationCenters;
        }

        public async Task<ActionResult<VaccinationCenter>> GetVaccinationCenter(int id)
        {
            VaccinationCenter vaccinationCenter = await _vaccinationContext.VaccinationCenters.FirstOrDefaultAsync(x => x.id == id);
            return vaccinationCenter;
        }

        public void AddVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            _vaccinationContext.AddAsync(vaccinationCenter);
        }

        public void UpdateVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            _vaccinationContext.Entry(vaccinationCenter).State = EntityState.Modified;
        }

        public async Task<string> DeleteVaccinationCenter(int id)
        {
            VaccinationCenter vaccinationCenter = await _vaccinationContext.VaccinationCenters.FirstOrDefaultAsync(x => x.id == id);

            if (vaccinationCenter == null)
            {
                return "El centro de vacunacion no existe";
            }
            _vaccinationContext.VaccinationCenters.Remove(vaccinationCenter);

            return "Centro de Vacunacion eliminado";
        }
    }
}
