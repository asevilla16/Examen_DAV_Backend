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
    public class VaccinationControlAppService : IVaccinationControlAppService
    {
        private readonly VaccinationContext _vaccinationContext;

        public VaccinationControlAppService(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }

        public async Task<IEnumerable<VaccinationControl>> GetVaccinationControls()
        {
            List<VaccinationControl> vaccinationControls = await _vaccinationContext.VaccinationControls.Include(p => p.Pacient).Include(c => c.VaccinationCenter).Include(v => v.Vaccine).ToListAsync();
            return vaccinationControls;
        }

        public async Task<ActionResult<VaccinationControl>> GetVaccinationControl(int id)
        {
            VaccinationControl vaccinationControl = await _vaccinationContext.VaccinationControls.Include(p => p.Pacient).Include(c => c.VaccinationCenter).Include(v => v.Vaccine).FirstOrDefaultAsync(x => x.id == id);
            return vaccinationControl;
        }

        public void AddVaccinationControl(VaccinationControl vaccinationControl)
        {
            _vaccinationContext.AddAsync(vaccinationControl);
        }

        public void UpdateVaccinationControl(VaccinationControl vaccinationControl)
        {
            _vaccinationContext.Entry(vaccinationControl).State = EntityState.Modified;
        }

        public async Task<string> DeleteVaccinationControl(int id)
        {
            VaccinationControl vaccinationControl = await _vaccinationContext.VaccinationControls.FirstOrDefaultAsync(x => x.id == id);

            if (vaccinationControl == null)
            {
                return "El registro de vacunacion no existe";
            }
            _vaccinationContext.VaccinationControls.Remove(vaccinationControl);

            return "Registro de vacunacion eliminado";
        }
    }
}
