using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.BankBranch;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBranchController : ControllerBase
    {
        private readonly IBankBranchService _bankBranchService;

        public BankBranchController(IBankBranchService bankBranchService)
        {
            _bankBranchService = bankBranchService;
        }
        [HttpPost("bankBranch-insert")]
        public async Task<IActionResult> AllNew(BankBranchDTO bankBranchDto)
        {
            var response = await _bankBranchService.AddNew(bankBranchDto);
            return Ok(response);
        }
        [HttpPost("bankBranch-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _bankBranchService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _bankBranchService.GetById(id);
            return Ok(response);
        }
        [HttpPut("bankBranch-update")]
        public async Task<BaseResponse> Update(UpdateBankBranchDTO update)
        {
            var response = await _bankBranchService.Update(update);
            return response;
        }
        [HttpDelete("bankBranch-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _bankBranchService.Delete(ids);
            return Ok(response);
        }
    }
}
