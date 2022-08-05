using Manage.Common;
using Manage.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Allowance;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class AllowanceController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public AllowanceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("allowance-insert")]
        public async Task<IActionResult> AllNew( AllowanceDTO allowanceDto)
        {
            var response = await _serviceWrapper.Allowance.AddNew(allowanceDto);
            return Ok(response);
        }
        [HttpPost("allowance-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _serviceWrapper.Allowance.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Allowance.GetById(id);
            return Ok(response);
        }
        [HttpPut("allowance-update")]
        public async Task<BaseResponse> Update( UpdateAllowanceDTO update)
        {
            var response = await _serviceWrapper.Allowance.Update(update);
            return response;
        }
        [HttpPut("allowance-update-status")]
        public async Task<BaseResponse> UpdateStatus(int id)
        {
            var response = await _serviceWrapper.Allowance.ChangeStatus(id);
            return response;
        }
        [HttpDelete("allowance-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Allowance.Delete(ids);
            return Ok(response);
        }
    }
}
