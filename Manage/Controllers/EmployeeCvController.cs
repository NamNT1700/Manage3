using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.EmployeeCv;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCvController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeCvController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employeeCv-insert")]
        public async Task<IActionResult> AllNew(EmployeeCvDTO employeeCvDto)
        {
            var response = await _serviceWrapper.EmployeeCv.AddNew(employeeCvDto);
            return Ok(response);
        }
        //[HttpPost("employeeCv-get-all")]
        //public async Task<IActionResult> GetAll(BaseRequest request)
        //{
        //    var response = await _employeeCvService.GetAll(request);
        //    return Ok(response);
        //}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.EmployeeCv.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeCv-update")]
        public async Task<BaseResponse> Update(UpdateEmployeeCvDTO update)
        {
            var response = await _serviceWrapper.EmployeeCv.Update(update);
            return response;
        }
        [HttpDelete("employeeCv-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.EmployeeCv.Delete(ids);
            return Ok(response);
        }
    }
}
