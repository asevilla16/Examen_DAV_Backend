using Examen2_DAV_AngelSevilla.Interface;
using Examen2_DAV_AngelSevilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccinesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Vaccine>> GetVaccines()
        {
            var response = await _unitOfWork.vaccineAppService.GetVaccines();
            return response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            var response = _unitOfWork.vaccineAppService.GetVaccine(id);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccine(Vaccine vaccine)
        {
            _unitOfWork.vaccineAppService.UpdateVaccine(vaccine);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pacient>> PostVaccine(Vaccine vaccine)
        {
            _unitOfWork.vaccineAppService.AddVaccine(vaccine);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction("GetVaccine", new { id = vaccine.id }, vaccine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            var response = await _unitOfWork.vaccineAppService.DeleteVaccine(id);

            await _unitOfWork.SaveChanges();

            return Ok(response);
        }
    }
}
