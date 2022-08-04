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
        Task<BaseResponse> Register(UserDTO reUser);
        Task<BaseResponse> GetAllUsers(BaseRequest request);
        Task<BaseResponse> Login(LoginDTO user);
        Task<BaseResponse> DeleteUsers(List<int> ids);
        Task<BaseResponse> FindUserById(int id);
        Task<BaseResponse> ChangeStatus(int id);
        Task<BaseResponse> RenewToken(RefreshTokenDTO refreshTokenDTO);
    }
}
