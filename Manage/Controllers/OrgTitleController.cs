using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.OrgTitle;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgTitleController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OrgTitleController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("orgTitle-insert")]
        public async Task<IActionResult> AllNew(OrgTitleDTO orgTitleDto)
        {
            var response = await _serviceWrapper.OrgTitle.AddNew(orgTitleDto);
            return Ok(response);
        }
        [HttpPost("orgTitle-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.OrgTitle.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.OrgTitle.GetById(id);
            return Ok(response);
        }
        [HttpPut("orgTitle-update")]
        public async Task<BaseResponse> Update(UpdateOrgTitleDTO update)
        {
            var response = await _serviceWrapper.OrgTitle.Update(update);
            return response;
        }
        [HttpDelete("orgTitle-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.OrgTitle.Delete(ids);
            return Ok(response);
        }
    }
}
