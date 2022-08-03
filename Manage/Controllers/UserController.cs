using Manage.Common;
using Manage.Model.DTO.User;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public UserController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser( UserDTO user)
        {
            BaseResponse res = await _serviceWrapper.User.Register(user);
            return Ok(res);
        }
        [HttpPost("get-all-users")]
        public async Task<IActionResult> GetAllUsers(BaseRequest baseRequest)
        {
            BaseResponse res = await _serviceWrapper.User.GetAllUsers(baseRequest);
            return Ok(res);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            BaseResponse res = await _serviceWrapper.User.Login(user);
            return Ok(res);
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> Delete(List<int> id)
        {
            BaseResponse res = await _serviceWrapper.User.DeleteUsers(id);
            return Ok(res);
        }
        [HttpPut("update-status-user")]
        // [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateStatusToInActive(int id)
        {
            BaseResponse res = await _serviceWrapper.User.ChangeStatusUser(id);
            return Ok(res);
        }

        [HttpPost("renew-token")]
        public async Task<IActionResult> RenewToken(RefreshTokenDTO refreshTokenDTO)
        {
            BaseResponse res = await _serviceWrapper.User.RenewToken(refreshTokenDTO);
            return Ok(res);
        }
    }
}
