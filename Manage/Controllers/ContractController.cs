using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Contract;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }
        [HttpPost("contract-insert")]
        public async Task<IActionResult> AllNew( ContractDTO contractDto)
        {
            var response = await _contractService.AddNew(contractDto);
            return Ok(response);
        }
        [HttpPost("contract-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _contractService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _contractService.GetById(id);
            return Ok(response);
        }
        [HttpPut("contract-update")]
        public async Task<IActionResult> Update(UpdateContractDTO update)
        {
            var response = await _contractService.Update(update);
            return Ok(response);
        }
        [HttpDelete("contract-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _contractService.Delete(ids);
            return Ok(response);
        }
    }
}
