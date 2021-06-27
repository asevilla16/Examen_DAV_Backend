using Examen2_DAV_AngelSevilla.AppService;
using Examen2_DAV_AngelSevilla.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VaccinationContext _vaccinationContext;

        public UnitOfWork(VaccinationContext vaccinationContext)
        {
            _vaccinationContext = vaccinationContext;
        }

        public IPacientAppService pacientAppService =>
            new PacientAppService(_vaccinationContext);

        public IVaccineAppService vaccineAppService =>
            new VaccineAppService(_vaccinationContext);

        public IDistributorAppService distributorAppService =>
            new DistributorAppService(_vaccinationContext);

        public IVaccinationCenterAppService vaccinationCenterAppService =>
            new VaccinationCenterAppService(_vaccinationContext);

        public IVaccinationControlAppService vaccinationControlAppService =>
            new VaccinationControlAppService(_vaccinationContext);

        public async Task<bool> SaveChanges()
        {
            return await _vaccinationContext.SaveChangesAsync() > 0;
        }
    }
}
