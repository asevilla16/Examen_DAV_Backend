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
    public class DistributorAppService : IDistributorAppService
    {
        private readonly VaccinationContext _vaccinationContext;

        public DistributorAppService(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }

        public async Task<IEnumerable<Distributor>> GetDistributors()
        {
            List<Distributor> distributors = await _vaccinationContext.Distributors.ToListAsync();
            return distributors;
        }

        public async Task<ActionResult<Distributor>> GetDistributor(int id)
        {
            Distributor distributor = await _vaccinationContext.Distributors.FirstOrDefaultAsync(x => x.id == id);
            return distributor;
        }

        public void AddDistributor(Distributor distributor)
        {
            _vaccinationContext.AddAsync(distributor);
        }

        public void UpdateDistributor(Distributor distributor)
        {
            _vaccinationContext.Entry(distributor).State = EntityState.Modified;
        }

        public async Task<string> DeleteDistributor(int id)
        {
            Distributor distributor = await _vaccinationContext.Distributors.FirstOrDefaultAsync(x => x.id == id);

            if (distributor == null)
            {
                return "El distribuidor no existe";
            }
            _vaccinationContext.Distributors.Remove(distributor);

            return "Distribuidor eliminado";
        }

    }
}
