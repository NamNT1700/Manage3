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
        private readonly IServiceWrapper _serviceWrapper;

        public ContractualBenefitController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("contractualBenefit-insert")]
        public async Task<IActionResult> AllNew(ContractualBenefitDTO contractualBenefitDto)
        {
            var response = await _serviceWrapper.ContractualBenefit.AddNew(contractualBenefitDto);
            return Ok(response);
        }
        [HttpPost("contractualBenefit-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.ContractualBenefit.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.ContractualBenefit.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractualBenefit-update")]
        public async Task<BaseResponse> Update(UpdateContractualBenefitDTO update)
        {
            var response = await _serviceWrapper.ContractualBenefit.Update(update);
            return response;
        }
        [HttpPut("contractBenefit-update-status")]
        public async Task<BaseResponse> UpdateStatus(int id)
        {
            var response = await _serviceWrapper.ContractualBenefit.ChangeStatus(id);
            return response;
        }
        [HttpDelete("contractualBenefit-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.ContractualBenefit.Delete(ids);
            return Ok(response);
        }
    }
}
