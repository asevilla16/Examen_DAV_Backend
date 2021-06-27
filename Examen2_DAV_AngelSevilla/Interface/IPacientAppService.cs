using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Interface
{
    public interface IPacientAppService
    {
        Task<IEnumerable<Pacient>> GetPacients();
        Task<ActionResult<Pacient>> GetPacient(int id);
        void AddPacient(Pacient pacient);
        void UpdatePacient(Pacient pacient);
        Task<string> DeletePacient(int id);
    }
}
