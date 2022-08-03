using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFamilyController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeFamilyController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employeeFamily-insert")]
        public async Task<IActionResult> AllNew(EmployeeFamilyDTO employeeFamilyDto)
        {
            var response = await _serviceWrapper.EmployeeFamily.AddNew(employeeFamilyDto);
            return Ok(response);
        }
        //[HttpPost("employeeFamily-get-all")]
        //public async Task<IActionResult> GetAll(BaseRequest request)
        //{
        //    var response = await _employeeFamilyService.GetAll(request);
        //    return Ok(response);
        //}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.EmployeeFamily.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeFamily-update")]
        public async Task<BaseResponse> Update(UpdateEmployeeFamilyDTO update)
        {
            var response = await _serviceWrapper.EmployeeFamily.Update(update);
            return response;
        }
        [HttpDelete("employeeFamily-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.EmployeeFamily.Delete(ids);
            return Ok(response);
        }
    }
}
