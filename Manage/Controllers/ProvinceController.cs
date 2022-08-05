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
        private readonly IServiceWrapper _serviceWrapper;

        public ProvinceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("province-insert")]
        public async Task<IActionResult> AllNew(ProvinceDTO provinceDto)
        {
            var response = await _serviceWrapper.Province.AddNew(provinceDto);
            return Ok(response);
        }
        [HttpPost("province-get-all")]
        public async Task<IActionResult> GetAll(BaseRequest request)
        {
            var response = await _serviceWrapper.Province.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _serviceWrapper.Province.GetById(id);
            return Ok(response);
        }
        [HttpPut("province-update")]
        public async Task<BaseResponse> Update(UpdateProvinceDTO update)
        {
            var response = await _serviceWrapper.Province.Update(update);
            return response;
        }
        [HttpPut("province-update-status")]
        public async Task<BaseResponse> UpdateStatus(int id)
        {
            var response = await _serviceWrapper.Province.ChangeStatus(id);
            return response;
        }
        [HttpDelete("province-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _serviceWrapper.Province.Delete(ids);
            return Ok(response);
        }
    }
}
