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
    public class VaccinationCentersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccinationCentersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<VaccinationCenter>> GetVaccinationCenters()
        {
            var response = await _unitOfWork.vaccinationCenterAppService.GetVaccinationCenters();
            return response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<VaccinationCenter>> GetVaccinationCenter(int id)
        {
            var response = _unitOfWork.vaccinationCenterAppService.GetVaccinationCenter(id);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            _unitOfWork.vaccinationCenterAppService.UpdateVaccinationCenter(vaccinationCenter);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationCenter>> PostVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            _unitOfWork.vaccinationCenterAppService.AddVaccinationCenter(vaccinationCenter);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction("GetVaccinationCenter", new { id = vaccinationCenter.id }, vaccinationCenter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinationCenter(int id)
        {
            var response = await _unitOfWork.vaccinationCenterAppService.DeleteVaccinationCenter(id);

            await _unitOfWork.SaveChanges();

            return Ok(response);
        }
    }
}
