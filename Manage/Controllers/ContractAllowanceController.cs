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
        private readonly IServiceWrapper _serviceWrapper;

        public ContractAllowanceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("contractAllowance-insert")]
        public async Task<IActionResult> AllNew(ContractAllowanceDTO contractAllowanceDto)
        {
            var response = await _serviceWrapper.ContractAllowance.AddNew(contractAllowanceDto);
            return Ok(response);
        }
        [HttpPost("contractAllowance-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.ContractAllowance.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.ContractAllowance.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractAllowance-update")]
        public async Task<BaseResponse> Update(UpdateContractAllowanceDTO update)
        {
            var response = await _serviceWrapper.ContractAllowance.Update(update);
            return response;
        }
        [HttpDelete("contractAllowance-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.ContractAllowance.Delete(ids);
            return Ok(response);
        }
    }
}
