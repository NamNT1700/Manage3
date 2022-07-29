using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.EmployeeEducation;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEducationController : ControllerBase
    {
        private readonly IEmployeeEducationService _employeeEducationService;

        public EmployeeEducationController(IEmployeeEducationService employeeEducationService)
        {
            _employeeEducationService = employeeEducationService;
        }
        [HttpPost("employeeEducation-insert")]
        public async Task<IActionResult> AllNew(EmployeeEducationDTO employeeEducationDto)
        {
            var response = await _employeeEducationService.AddNew(employeeEducationDto);
            return Ok(response);
        }
        [HttpPost("employeeEducation-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _employeeEducationService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _employeeEducationService.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeEducation-update")]
        public async Task<BaseResponse> Update(UpdateEmployeeEducationDTO update)
        {
            var response = await _employeeEducationService.Update(update);
            return response;
        }
        [HttpDelete("employeeEducation-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _employeeEducationService.Delete(ids);
            return Ok(response);
        }
    }
}
