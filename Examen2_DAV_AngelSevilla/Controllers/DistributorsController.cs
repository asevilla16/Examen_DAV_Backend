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
    public class DistributorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistributorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Distributor>> GetDistributors()
        {
            var response = await _unitOfWork.distributorAppService.GetDistributors();
            return response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Distributor>> GetDistributor(int id)
        {
            var response = _unitOfWork.distributorAppService.GetDistributor(id);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributor(Distributor distributor)
        {
            _unitOfWork.distributorAppService.UpdateDistributor(distributor);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Distributor>> PostDistributor(Distributor distributor)
        {
            _unitOfWork.distributorAppService.AddDistributor(distributor);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction("GetDistributor", new { id = distributor.id }, distributor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributor(int id)
        {
            var response = await _unitOfWork.distributorAppService.DeleteDistributor(id);

            await _unitOfWork.SaveChanges();

            return Ok(response);
        }
    }
}
