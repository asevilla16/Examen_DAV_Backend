using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IDistributorAppService
    {
        Task<IEnumerable<Distributor>> GetDistributors();
        Task<ActionResult<Distributor>> GetDistributor(int id);
        void AddDistributor(Distributor distributor);
        void UpdateDistributor(Distributor distributor);
        Task<string> DeleteDistributor(int id);
    }
}
