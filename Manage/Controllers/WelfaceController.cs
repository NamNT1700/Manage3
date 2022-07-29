using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Welface;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelfaceController : ControllerBase
    {
        private readonly IWelfaceService _welfaceService;

        public WelfaceController(IWelfaceService welfaceService)
        {
            _welfaceService = welfaceService;
        }
        [HttpPost("welfare-insert")]
        public async Task<IActionResult> AllNew(WelfaceDTO welfareDto)
        {
            var response = await _welfaceService.AddNew(welfareDto);
            return Ok(response);
        }
        [HttpPost("welfare-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _welfaceService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _welfaceService.GetById(id);
            return Ok(response);
        }
        [HttpPut("welfare-update")]
        public async Task<BaseResponse> Update(UpdateWelfaceDTO update)
        {
            var response = await _welfaceService.Update(update);
            return response;
        }
        [HttpDelete("welfare-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _welfaceService.Delete(ids);
            return Ok(response);
        }
    }
}
