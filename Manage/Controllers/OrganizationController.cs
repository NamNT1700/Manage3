using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Organization;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [HttpPost("organization-insert")]
        public async Task<IActionResult> AllNew(OrganizationDTO organizationDto)
        {
            var response = await _organizationService.AddNew(organizationDto);
            return Ok(response);
        }
        [HttpPost("organization-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _organizationService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _organizationService.GetById(id);
            return Ok(response);
        }
        [HttpPut("organization-update")]
        public async Task<BaseResponse> Update(UpdateOrganizationDTO update)
        {
            var response = await _organizationService.Update(update);
            return response;
        }
        [HttpDelete("organization-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _organizationService.Delete(ids);
            return Ok(response);
        }
    }
}
