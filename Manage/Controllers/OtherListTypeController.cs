using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.OtherListType;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherListTypeController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OtherListTypeController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("otherListType-insert")]
        public async Task<IActionResult> AllNew(OtherListTypeDTO otherListTypeDto)
        {
            var response = await _serviceWrapper.OtherListType.AddNew(otherListTypeDto);
            return Ok(response);
        }
        [HttpPost("otherListType-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.OtherListType.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.OtherListType.GetById(id);
            return Ok(response);
        }
        [HttpPut("otherListType-update")]
        public async Task<BaseResponse> Update(UpdateOtherListTypeDTO update)
        {
            var response = await _serviceWrapper.OtherListType.Update(update);
            return response;
        }
      
        [HttpDelete("otherListType-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.OtherListType.Delete(ids);
            return Ok(response);
        }
    }
}
