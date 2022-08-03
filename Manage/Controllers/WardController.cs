using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Ward;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public WardController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("ward-insert")]
        public async Task<IActionResult> AllNew(WardDTO wardDto)
        {
            var response = await _serviceWrapper.Ward.AddNew(wardDto);
            return Ok(response);
        }
        [HttpPost("ward-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.Ward.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Ward.GetById(id);
            return Ok(response);
        }
        [HttpPut("ward-update")]
        public async Task<BaseResponse> Update(UpdateWardDTO update)
        {
            var response = await _serviceWrapper.Ward.Update(update);
            return response;
        }
        [HttpDelete("ward-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Ward.Delete(ids);
            return Ok(response);
        }
    }
}
