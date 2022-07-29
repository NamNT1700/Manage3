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
        private readonly IOrgTitleService _orgTitleService;

        public OrgTitleController(IOrgTitleService orgTitleService)
        {
            _orgTitleService = orgTitleService;
        }
        [HttpPost("orgTitle-insert")]
        public async Task<IActionResult> AllNew(OrgTitleDTO orgTitleDto)
        {
            var response = await _orgTitleService.AddNew(orgTitleDto);
            return Ok(response);
        }
        [HttpPost("orgTitle-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _orgTitleService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _orgTitleService.GetById(id);
            return Ok(response);
        }
        [HttpPut("orgTitle-update")]
        public async Task<BaseResponse> Update(UpdateOrgTitleDTO update)
        {
            var response = await _orgTitleService.Update(update);
            return response;
        }
        [HttpDelete("orgTitle-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _orgTitleService.Delete(ids);
            return Ok(response);
        }
    }
}
