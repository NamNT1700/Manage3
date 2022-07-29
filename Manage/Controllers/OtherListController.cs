using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.OtherList;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherListController : ControllerBase
    {
        private readonly IOtherListService _otherListService;

        public OtherListController(IOtherListService otherListService)
        {
            _otherListService = otherListService;
        }
        [HttpPost("otherList-insert")]
        public async Task<IActionResult> AllNew(OtherListDTO otherListDto)
        {
            var response = await _otherListService.AddNew(otherListDto);
            return Ok(response);
        }
        [HttpPost("otherList-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _otherListService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _otherListService.GetById(id);
            return Ok(response);
        }
        [HttpPut("otherList-update")]
        public async Task<BaseResponse> Update(UpdateOtherListDTO update)
        {
            var response = await _otherListService.Update(update);
            return response;
        }
        [HttpDelete("otherList-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _otherListService.Delete(ids);
            return Ok(response);
        }
    }
}
