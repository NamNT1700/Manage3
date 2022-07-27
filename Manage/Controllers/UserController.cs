using Manage.Common;
using Manage.Model.DTO.User;
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
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser( UserDTO user)
        {
            BaseResponse res = await _userService.Register(user);
            return Ok(res);
        }
        [HttpPost("get-all-users")]
        public async Task<IActionResult> GetAllUsers(BaseRequest baseRequest)
        {
            BaseResponse res = await _userService.GetAllUsers(baseRequest);
            return Ok(res);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            BaseResponse res = await _userService.Login(user);
            return Ok(res);
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> Delete(List<int> id)
        {
            BaseResponse res = await _userService.DeleteUsers(id);
            return Ok(res);
        }
        [HttpPut("update-status-user")]
        // [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateStatusToInActive(UserDTO user)
        {
            BaseResponse res = await _userService.ChangeStatusUser(user);
            return Ok(res);
        }

        [HttpPost("renew-token")]
        public async Task<IActionResult> RenewToken(RefreshTokenDTO refreshTokenDTO)
        {
            BaseResponse res = await _userService.RenewToken(refreshTokenDTO);
            return Ok(res);
        }
    }
}
