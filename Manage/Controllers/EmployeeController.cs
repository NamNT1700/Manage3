﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Employee;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employee-insert")]
        public async Task<IActionResult> AllNew(EmployeeDTO employeeDto)
        {
            var response = await _serviceWrapper.Employee.AddNew(employeeDto);
            return Ok(response);
        }
        [HttpPost("employee-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.Employee.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Employee.GetById(id);
            return Ok(response);
        }
        [HttpPut("employee-update")]
        public async Task<BaseResponse> Update(UpdateEmployeeDTO update)
        {
            var response = await _serviceWrapper.Employee.Update(update);
            return response;
        }
        [HttpDelete("employee-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Employee.Delete(ids);
            return Ok(response);
        }
    }
}
