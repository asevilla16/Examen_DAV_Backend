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
    public class PacientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PacientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Pacient>> GetPacients()
        {
            var response = await _unitOfWork.pacientAppService.GetPacients();
            return response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Pacient>> GetPacient(int id)
        {
            var response = _unitOfWork.pacientAppService.GetPacient(id);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacient(Pacient pacient)
        {
            _unitOfWork.pacientAppService.UpdatePacient(pacient);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pacient>> PostPacient(Pacient pacient)
        {
            _unitOfWork.pacientAppService.AddPacient(pacient);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction("GetPacient", new { id = pacient.id }, pacient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacient(int id)
        {
            var response = await _unitOfWork.pacientAppService.DeletePacient(id);

            await _unitOfWork.SaveChanges();

            return Ok(response);
        }
    }
}
