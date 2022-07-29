using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.ContractAllowance;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractAllowanceController : ControllerBase
    {
        private readonly IContractAllowanceService _contractAllowanceService;

        public ContractAllowanceController(IContractAllowanceService contractAllowanceService)
        {
            _contractAllowanceService = contractAllowanceService;
        }
        [HttpPost("contractAllowance-insert")]
        public async Task<IActionResult> AllNew(ContractAllowanceDTO contractAllowanceDto)
        {
            var response = await _contractAllowanceService.AddNew(contractAllowanceDto);
            return Ok(response);
        }
        [HttpPost("contractAllowance-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _contractAllowanceService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _contractAllowanceService.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractAllowance-update")]
        public async Task<BaseResponse> Update(UpdateContractAllowanceDTO update)
        {
            var response = await _contractAllowanceService.Update(update);
            return response;
        }
        [HttpDelete("contractAllowance-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _contractAllowanceService.Delete(ids);
            return Ok(response);
        }
    }
}
