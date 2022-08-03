//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Manage.Common;
//using Manage.Model.DTO.BankBranch;
//using Manage.Model.DTO.OtherListType;
//using Manage.Service.IService;

//namespace Manage.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OtherListTypeController : ControllerBase
//    {
//        private readonly IOtherListTypeService _otherListTypeService;

//        public OtherListTypeController(IOtherListTypeService otherListTypeService)
//        {
//            _otherListTypeService = otherListTypeService;
//        }
//        [HttpPost("otherListType-insert")]
//        public async Task<IActionResult> AllNew(OtherListTypeDTO otherListTypeDto)
//        {
//            var response = await _otherListTypeService.AddNew(otherListTypeDto);
//            return Ok(response);
//        }
//        [HttpPost("otherListType-get-all")]
//        public async Task<IActionResult> GetAll(BaseRequest request)
//        {
//            var response = await _otherListTypeService.GetAll(request);
//            return Ok(response);
//        }
//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetAll(int id)
//        {
//            var response = await _otherListTypeService.GetById(id);
//            return Ok(response);
//        }
//        [HttpPut("otherListType-update")]
//        public async Task<BaseResponse> Update(UpdateOtherListTypeDTO update)
//        {
//            var response = await _otherListTypeService.Update(update);
//            return response;
//        }
//        [HttpDelete("otherListType-delete")]
//        public async Task<IActionResult> Delete(List<int> ids)
//        {
//            var response = await _otherListTypeService.Delete(ids);
//            return Ok(response);
//        }
//    }
//}
