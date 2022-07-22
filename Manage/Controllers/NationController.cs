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
        private ITitleService _titleService;
        public NationController(ITitleService titleService)
        {
            _titleService = titleService;
        }
        [HttpPost("AddNewNation")]
        public async Task<IActionResult> AllNew( TitleDTO title)
        {
            Response response = await _titleService.AddNew(title);
            return Ok(response);
        }
        [HttpPost("GetAllNation")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            Response response = await _titleService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            Response response = await _titleService.GetById(id);
            return Ok(response);
        }
        [HttpPut("UpdateNation")]
        public async Task<IActionResult> Update(UpdateTitleDTO update)
        {
            Response response = await _titleService.Update(update);
            return Ok(response);
        }
        [HttpDelete("DeleteNation")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            Response response = await _titleService.Delete(ids);
            return Ok(response);
        }
    }
}
