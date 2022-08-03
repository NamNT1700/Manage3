using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.School;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public SchoolController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("school-insert")]
        public async Task<IActionResult> AllNew(SchoolDTO schoolDto)
        {
            var response = await _serviceWrapper.School.AddNew(schoolDto);
            return Ok(response);
        }
        [HttpPost("school-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.School.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.School.GetById(id);
            return Ok(response);
        }
        [HttpPut("school-update")]
        public async Task<BaseResponse> Update(UpdateSchoolDTO update)
        {
            var response = await _serviceWrapper.School.Update(update);
            return response;
        }
        [HttpDelete("school-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.School.Delete(ids);
            return Ok(response);
        }
    }
}
