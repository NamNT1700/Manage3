using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Province;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [HttpPost("province-insert")]
        public async Task<IActionResult> AllNew(ProvinceDTO provinceDto)
        {
            var response = await _provinceService.AddNew(provinceDto);
            return Ok(response);
        }
        [HttpPost("province-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _provinceService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _provinceService.GetById(id);
            return Ok(response);
        }
        [HttpPut("province-update")]
        public async Task<BaseResponse> Update(UpdateProvinceDTO update)
        {
            var response = await _provinceService.Update(update);
            return response;
        }
        [HttpDelete("province-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _provinceService.Delete(ids);
            return Ok(response);
        }
    }
}
