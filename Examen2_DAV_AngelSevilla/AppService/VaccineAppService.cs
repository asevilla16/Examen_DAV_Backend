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
    public class VaccineAppService : IVaccineAppService
    {
        private readonly VaccinationContext _vaccinationContext;

        public VaccineAppService(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }

        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            Vaccine vaccine = await _vaccinationContext.Vaccines.Include(v => v.Distributor).FirstOrDefaultAsync(x => x.id == id);
            return vaccine;
        }

        public async Task<IEnumerable<Vaccine>> GetVaccines()
        {
            List<Vaccine> vaccines = await _vaccinationContext.Vaccines.Include(v => v.Distributor).ToListAsync();
            return vaccines;
        }
        public void AddVaccine(Vaccine vaccine)
        {
            _vaccinationContext.AddAsync(vaccine);
        }

        public void UpdateVaccine(Vaccine vaccine)
        {
            _vaccinationContext.Entry(vaccine).State = EntityState.Modified;
        }
        public async Task<string> DeleteVaccine(int id)
        {
            Vaccine vaccine = await _vaccinationContext.Vaccines.FirstOrDefaultAsync(x => x.id == id);

            if (vaccine == null)
            {
                return "La Vacuna no existe";
            }
            _vaccinationContext.Vaccines.Remove(vaccine);

            return "Vacuna eliminada";
        }
    }
}
