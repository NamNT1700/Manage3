using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.District;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpPost("district-insert")]
        public async Task<IActionResult> AllNew(DistrictDTO districtDto)
        {
            var response = await _districtService.AddNew(districtDto);
            return Ok(response);
        }
        [HttpPost("district-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _districtService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _districtService.GetById(id);
            return Ok(response);
        }
        [HttpPut("district-update")]
        public async Task<BaseResponse> Update(UpdateDistrictDTO update)
        {
            var response = await _districtService.Update(update);
            return response;
        }
        [HttpDelete("district-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _districtService.Delete(ids);
            return Ok(response);
        }
    }
}
