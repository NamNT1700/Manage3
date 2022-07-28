using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Hospital;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        [HttpPost("AddNewHospital")]
        public async Task<IActionResult> AllNew( HospitalDTO hospital)
        {
            var response = await _hospitalService.AddNew(hospital);
            return Ok(response);
        }
        [HttpPost("GetAllHospital")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _hospitalService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _hospitalService.GetById(id);
            return Ok(response);
        }
        [HttpPut("UpdateHospital")]
        public async Task<IActionResult> Update(UpdateHospitalDTO update)
        {
            var response = await _hospitalService.Update(update);
            return Ok(response);
        }
        [HttpDelete("DeleteHospital")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _hospitalService.Delete(ids);
            return Ok(response);
        }
    }
}
