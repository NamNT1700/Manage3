﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.SalaryRecord;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryRecordController : ControllerBase
    {
        private readonly ISalaryRecordService _salaryRecordService;

        public SalaryRecordController(ISalaryRecordService salaryRecordService)
        {
            _salaryRecordService = salaryRecordService;
        }
        [HttpPost("salaryRecord-insert")]
        public async Task<IActionResult> AllNew(SalaryRecordDTO salaryRecordDto)
        {
            var response = await _salaryRecordService.AddNew(salaryRecordDto);
            return Ok(response);
        }
        [HttpPost("salaryRecord-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _salaryRecordService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _salaryRecordService.GetById(id);
            return Ok(response);
        }
        [HttpPut("salaryRecord-update")]
        public async Task<BaseResponse> Update(UpdateSalaryRecordDTO update)
        {
            var response = await _salaryRecordService.Update(update);
            return response;
        }
        [HttpDelete("salaryRecord-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _salaryRecordService.Delete(ids);
            return Ok(response);
        }
    }
}
