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
        private readonly ITitleService _titleService;

        public NationController(ITitleService titleService)
        {
            _titleService = titleService;
        }
        [HttpPost("nation-insert")]
        public async Task<IActionResult> AllNew( TitleDTO title)
        {
            var response = await _titleService.AddNew(title);
            return Ok(response);
        }
        [HttpPost("nation-get-all")]
        public async Task<IActionResult> GetAll( BaseRequest request)
        {
            var response = await _titleService.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _titleService.GetById(id);
            return Ok(response);
        }
        [HttpPut("nation-update")]
        public async Task<IActionResult> Update(UpdateTitleDTO update)
        {
            var response = await _titleService.Update(update);
            return Ok(response);
        }
        [HttpDelete("nation-delete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var response = await _titleService.Delete(ids);
            return Ok(response);
        }
    }
}
