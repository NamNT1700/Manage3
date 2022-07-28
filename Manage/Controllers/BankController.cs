﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Bank;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpPost("bank-insert")]
        public async Task<IActionResult> AllNewBank(BankDTO bankDto)
        {
            var response = await _bankService.AddNew(bankDto);
            BaseResponse response = await _bankService.AddNew(bankDto);
            BaseResponse response = await _bankService.AddNewBank(bankDto);
            return Ok(response);
        }
        [HttpPost("bank-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _bankService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _bankService.GetById(id);
            return Ok(response);
        }
        [HttpPut("bank-update")]
        public async Task<IActionResult> Update(UpdateBankDTO update)
        {
            var response = await _bankService.Update(update);
            return Ok(response);
        }
        [HttpDelete("bank-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _bankService.Delete(ids);
            return Ok(response);
        }
    }
}
