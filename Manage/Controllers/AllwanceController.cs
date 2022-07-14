using Manage.Common;
using Manage.Model.DTO.Allwance;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllwanceController : ControllerBase
    {
        private IAllwanceService _allwanceService;
        public AllwanceController (IAllwanceService allwanceService)
        {
            _allwanceService = allwanceService;
        }
        [HttpPost("AddNewAllwance")]
        public async Task<IActionResult> AllNew([FromBody] AllwanceDTO allwanceDTO)
        {
            Response response = await _allwanceService.AddNew(allwanceDTO);
            return Ok(response);
        }
    }
}
