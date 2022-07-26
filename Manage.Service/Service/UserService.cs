using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Manage.Service.Service
{
    public class UserService :  IUserService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response> ChangeStatusUser(UserDTO user)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]; //get token
            Response response = new Response();
            TokenGenarate accessToken = new TokenGenarate(_configuration);
            TokenDecode tokenDecode = accessToken.TokenInfo(token);
            if (accessToken.CheckToken(tokenDecode) != null) return accessToken.CheckToken(tokenDecode);
            SeUser existUser = await _repositoryWrapper.User.FindById(user.id);
            if (existUser.ActiveFlg == "A")
                existUser.ActiveFlg = "I";
            if (existUser.ActiveFlg == "I")
                existUser.ActiveFlg = "A";
            existUser.LastUpdatedBy = tokenDecode.username;
            existUser.LastUpdateTime = DateTime.UtcNow;
            await _repositoryWrapper.User.Update(existUser);
            await _context.SaveChangesAsync();
            response.status = "200";
            response.success = true;
            response.message = $"Status of users is changed";
            return response;
        }

        public async Task<Response> DeleteUsers(List<int> ids)
        {
            Response response = new Response();
            foreach (int id in ids)
            {
                SeUser existUser = await _repositoryWrapper.User.FindById(id);
                if (existUser != null)
                    await _repositoryWrapper.User.Delete(existUser);
            }
            response.status = "200";
            response.success = true;
            response.message = "Delete success";
            return response;
        }

        public async Task<Response> FindUserById(int id)
        {
            Response respones = new Response();
            SeUser existUser = await _repositoryWrapper.User.FindById(id);
            if (existUser == null)
            {
                respones.status = "400";
                respones.success = false;
                respones.message = "User not exist";
                return respones;
            }
            respones.status = "200";
            respones.success = true;
            respones.item = existUser;
            return respones;
        }

        public async Task<Response> GetAllUsers(BaseRequest request)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]; //get token
            Response response = new Response();
            TokenGenarate accessToken = new TokenGenarate(_configuration);
            TokenDecode tokenDecode= accessToken.TokenInfo(token);
            if (accessToken.CheckToken(tokenDecode) != null) return accessToken.CheckToken(tokenDecode);
            List<SeUser> allUsers = await _repositoryWrapper.User.FindAllData(request);
            List<ListUserDTO> listUser = _mapper.Map<List<ListUserDTO>>(allUsers);
            response.status = "Success";
            response.success = true;
            response.item = listUser;
            return response;
        }

        public async Task<Response> Login(LoginDTO user)
        {
            Response respones = new Response();
            string encodePass = CodingPassword.EncodingUTF8(user.password);
            string description = await _repositoryWrapper.User.CheckUserLogin(user.username, encodePass);
            if (description == null)
            {
                SeToken seToken = new SeToken();
                SeUser loginUser = await _repositoryWrapper.User.FindByUsername(user.username);
                TokenGenarate genToken = new TokenGenarate(_configuration);
                seToken = genToken.GenerateTokens(loginUser);
                loginUser.access_token = seToken.access_token;
                loginUser.refresh_token = seToken.refresh_token;
                loginUser.expired_time = DateTime.UtcNow.AddMinutes(1);
                await _repositoryWrapper.User.Update(loginUser);
                await _context.SaveChangesAsync();
                respones.status = "200";
                respones.success = true;
                respones.item = seToken;
                return respones;
            }
            respones.status = "400";
            respones.success = false;
            respones.message = description;
            return respones;
        }

        public async Task<Response> Register(UserDTO reUser)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]; //get token
            Response response = new Response();
            TokenGenarate accessToken = new TokenGenarate(_configuration);
            TokenDecode tokenDecode = accessToken.TokenInfo(token);
            if (accessToken.CheckToken(tokenDecode) != null) return accessToken.CheckToken(tokenDecode);
            SeUser description = await _repositoryWrapper.User.FindByUsername(reUser.username);
            if (description != null)
            {
                response.status = "400";
                response.success = false;
                response.message = "Username already exist";
                return response;
            }
            reUser.password = CodingPassword.EncodingUTF8(reUser.password);
            SeUser newUser = _mapper.Map<SeUser>(reUser);
            newUser.ActiveFlg = "A";
            newUser.CreatedBy = newUser.LastUpdatedBy = tokenDecode.username;
            newUser.CreatedTime = newUser.LastUpdateTime = DateTime.UtcNow; 
            await _repositoryWrapper.User.Create(newUser);
            newUser.Code = "Ue"+$"{newUser.Id}";
            await _context.SaveChangesAsync();
            response.status = "200";
            response.success = true;
            response.item = newUser;
            return response;
        }

        public async Task<Response> RenewToken(RefreshTokenDTO refreshTokenDTO)
        {
            Response response = new Response();
            bool isTrue = await _repositoryWrapper.User.CheckRefreshToken(refreshTokenDTO.username, refreshTokenDTO.refresh_token);
            if(!isTrue)
            {
                response.status = "407";
                response.success = false;
                response.message = "refresh token invalid";
                return response;
            }
            SeUser loginUser = await _repositoryWrapper.User.FindByUsername(refreshTokenDTO.username);
            TokenGenarate accessToken = new TokenGenarate(_configuration);
            string access_token = accessToken.GenerateAccessToken(loginUser);
            loginUser.access_token = access_token;
            await _repositoryWrapper.User.Update(loginUser);
            await _context.SaveChangesAsync();
            response.status = "200";
            response.success = true;
            response.message = "token is renew";
            response.item = access_token;
            return response;
        }
    }
}
