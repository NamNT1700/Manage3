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
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }
        [HttpPost("ward-insert")]
        public async Task<IActionResult> AllNew(WardDTO wardDto)
        {
            var response = await _wardService.AddNew(wardDto);
            return Ok(response);
        }
        [HttpPost("ward-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _wardService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _wardService.GetById(id);
            return Ok(response);
        }
        [HttpPut("ward-update")]
        public async Task<BaseResponse> Update(UpdateWardDTO update)
        {
            var response = await _wardService.Update(update);
            return response;
        }
        [HttpDelete("ward-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _wardService.Delete(ids);
            return Ok(response);
        }
    }
}
