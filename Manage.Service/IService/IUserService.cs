using Manage.Common;
using Manage.Model.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IUserService
    {
        public Task<BaseResponse> Register(UserDTO reUser);
        public Task<BaseResponse> GetAllUsers(BaseRequest request);
        public Task<BaseResponse> Login(LoginDTO user);
        public Task<BaseResponse> DeleteUsers(List<int> ids);
        public Task<BaseResponse> FindUserById(int id);
        public Task<BaseResponse> ChangeStatusUser(int id);
        public Task<BaseResponse> RenewToken(RefreshTokenDTO refreshTokenDTO);
    }
}
