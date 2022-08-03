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
        private readonly IServiceWrapper _serviceWrapper;

        public HospitalController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("hospital-insert")]
        public async Task<IActionResult> AllNew( HospitalDTO hospital)
        {
            var response = await _serviceWrapper.Hospital.AddNew(hospital);
            return Ok(response);
        }
        [HttpPost("hospital-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.Hospital.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Hospital.GetById(id);
            return Ok(response);
        }
        [HttpPut("hospital-update")]
        public async Task<IActionResult> Update(UpdateHospitalDTO update)
        {
            var response = await _serviceWrapper.Hospital.Update(update);
            return Ok(response);
        }
        [HttpDelete("hospital-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Hospital.Delete(ids);
            return Ok(response);
        }
    }
}
