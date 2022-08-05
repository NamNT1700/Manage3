using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Title;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class NationController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public NationController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("nation-insert")]
        public async Task<IActionResult> AllNew( NationDTO nation)
        {
            var response = await _serviceWrapper.Nation.AddNew(nation);
            return Ok(response);
        }
        [HttpPost("nation-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _serviceWrapper.Nation.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Nation.GetById(id);
            return Ok(response);
        }
        [HttpPut("nation-update")]
        public async Task<IActionResult> Update(UpdateNationDTO update)
        {
            var response = await _serviceWrapper.Nation.Update(update);
            return Ok(response);
        }
        [HttpDelete("nation-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Nation.Delete(ids);
            return Ok(response);
        }
        [HttpPut("nation-update-status")]
        public async Task<BaseResponse> UpdateStatus(int id)
        {
            var response = await _serviceWrapper.Nation.ChangeStatus(id);
            return response;
        }
    }
}
