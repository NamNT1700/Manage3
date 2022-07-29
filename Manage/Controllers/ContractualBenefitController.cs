using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractualBenefitController : ControllerBase
    {
        private readonly IContractualBenefitService _contractualBenefitService;

        public ContractualBenefitController(IContractualBenefitService contractualBenefitService)
        {
            _contractualBenefitService = contractualBenefitService;
        }
        [HttpPost("contractualBenefit-insert")]
        public async Task<IActionResult> AllNew(ContractualBenefitDTO contractualBenefitDto)
        {
            var response = await _contractualBenefitService.AddNew(contractualBenefitDto);
            return Ok(response);
        }
        [HttpPost("contractualBenefit-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _contractualBenefitService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _contractualBenefitService.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractualBenefit-update")]
        public async Task<BaseResponse> Update(UpdateContractualBenefitDTO update)
        {
            var response = await _contractualBenefitService.Update(update);
            return response;
        }
        [HttpDelete("contractualBenefit-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _contractualBenefitService.Delete(ids);
            return Ok(response);
        }
    }
}
