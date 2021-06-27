using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IUnitOfWork
    {
        IPacientAppService pacientAppService { get; }
        IVaccineAppService vaccineAppService { get; }
        IDistributorAppService distributorAppService { get; }
        IVaccinationCenterAppService vaccinationCenterAppService { get; }
        IVaccinationControlAppService vaccinationControlAppService { get; }

        Task<bool> SaveChanges();
    }
}
