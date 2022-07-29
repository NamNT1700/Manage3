using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Title;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }
        [HttpPost("title-insert")]
        public async Task<IActionResult> AllNew(TitleDTO titleDto)
        {
            var response = await _titleService.AddNew(titleDto);
            return Ok(response);
        }
        [HttpPost("title-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _titleService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _titleService.GetById(id);
            return Ok(response);
        }
        [HttpPut("title-update")]
        public async Task<IActionResult> Update(UpdateTitleDTO update)
        {
            var response = await _titleService.Update(update);
            return Ok(response);
        }
        [HttpDelete("title-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _titleService.Delete(ids);
            return Ok(response);
        }
    }
}
