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
    public class PacientAppService : IPacientAppService
    {
        private readonly VaccinationContext _vaccinationContext;

        public PacientAppService(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }
        public async Task<IEnumerable<Pacient>> GetPacients()
        {
            List<Pacient> pacients = await _vaccinationContext.Pacients.ToListAsync();
            return pacients;
        }

        public async Task<ActionResult<Pacient>> GetPacient(int id)
        {
            Pacient pacient = await _vaccinationContext.Pacients.FirstOrDefaultAsync(x => x.id == id);
            return pacient;
        }

        public void AddPacient(Pacient pacient)
        {
            _vaccinationContext.AddAsync(pacient);
        }
        public void UpdatePacient(Pacient pacient)
        {
            _vaccinationContext.Entry(pacient).State = EntityState.Modified;
        }

        public async Task<string> DeletePacient(int id)
        {
            Pacient pacient = await _vaccinationContext.Pacients.FirstOrDefaultAsync(x => x.id == id);

            if (pacient == null)
            {
                return "El paciente no existe";
            }
            _vaccinationContext.Pacients.Remove(pacient);

            return "Paciente eliminado";
        }

    }
}
