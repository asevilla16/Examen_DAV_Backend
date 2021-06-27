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
    public class VaccinationControlsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccinationControlsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<VaccinationControl>> GetVaccinationControls()
        {
            var response = await _unitOfWork.vaccinationControlAppService.GetVaccinationControls();
            return response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<VaccinationControl>> GetVaccinationControl(int id)
        {
            var response = _unitOfWork.vaccinationControlAppService.GetVaccinationControl(id);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccinationControl(VaccinationControl vaccinationControl)
        {
            _unitOfWork.vaccinationControlAppService.UpdateVaccinationControl(vaccinationControl);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationControl>> PostVaccinationControl(VaccinationControl vaccinationControl)
        {
            _unitOfWork.vaccinationControlAppService.AddVaccinationControl(vaccinationControl);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction("GetVaccinationControl", new { id = vaccinationControl.id }, vaccinationControl);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinationControl(int id)
        {
            var response = await _unitOfWork.vaccinationControlAppService.DeleteVaccinationControl(id);

            await _unitOfWork.SaveChanges();

            return Ok(response);
        }
    }
}
