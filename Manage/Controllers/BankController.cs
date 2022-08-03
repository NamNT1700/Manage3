using Microsoft.AspNetCore.Http;
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
        private readonly IServiceWrapper _serviceWrapper;

        public BankController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("bank-insert")]
        public async Task<IActionResult> AllNew(BankDTO bankDto)
        {
            var response = await _serviceWrapper.Bank.AddNew(bankDto);
            return Ok(response);
        }
        [HttpPost("bank-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _serviceWrapper.Bank.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Bank.GetById(id);
            return Ok(response);
        }
        [HttpPut("bank-update")]
        public async Task<IActionResult> Update(UpdateBankDTO update)
        {
            var response = await _serviceWrapper.Bank.Update(update);
            return Ok(response);
        }
        [HttpDelete("bank-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Bank.Delete(ids);
            return Ok(response);
        }
    }
}
