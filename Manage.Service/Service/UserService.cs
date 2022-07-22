﻿using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Repository.Base.IRepository.IWrapper;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Web;
//using Microsoft.AspNetCore.Http.IHeaderDictionary;

namespace Manage.Service.Service
{
    public class UserService :  IUserService
    {
        private IMapper _mapper;
        private IUserRepositoryWrapper _userRepositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, IUserRepositoryWrapper userRepositoryWrapper, DatabaseContext context,
            IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userRepositoryWrapper = userRepositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response> ChangeStatusUser(UserDTO user)
        {
            Response respones = new Response();
            SeUser existUser = await _userRepositoryWrapper.User.FindById(user.id);
            if (existUser.ActiveFlg == "A")
                existUser.ActiveFlg = "I";
            if (existUser.ActiveFlg == "I")
                existUser.ActiveFlg = "A";
            await _userRepositoryWrapper.User.Update(existUser);
            await _context.SaveChangesAsync();
            respones.status = "200";
            respones.success = true;
            respones.message = $"Status of users is changed";
            return respones;
        }

        public async Task<Response> DeleteUsers(List<int> ids)
        {
            Response response = new Response();
            foreach (int id in ids)
            {
                SeUser existUser = await _userRepositoryWrapper.User.FindById(id);
                if (existUser != null)
                    await _userRepositoryWrapper.User.Delete(existUser);
            }
            response.status = "200";
            response.success = true;
            response.message = "Delete success";
            return response;
        }

        public async Task<Response> FindUserById(int id)
        {
            Response respones = new Response();
            SeUser existUser = await _userRepositoryWrapper.User.FindById(id);
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

        public async Task<Response> GetAllUsers(BaseRequest request,string token)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            //Authorization
            var headerValue = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var a = headerValue.FirstOrDefault();
            Response response = new Response();
            //var a = _httpContextAccessor.HttpContext.Request.Headers["Authorization "];
            TokenGenarate accessToken = new TokenGenarate(_configuration);
            ClaimsPrincipal claimsPrincipal = accessToken.DecodeAccessToken(token);
            string role = claimsPrincipal.Claims.FirstOrDefault(t => t.Type.Equals("Role")).Value;
            if ( role != "string")
            {
                response.status = "403";
                response.success = false;
                response.message = "forbidden";
                response.item = headerValue;
                return response;
            }    
            List<SeUser> allUsers = await _userRepositoryWrapper.User.FindAllData();
            List<UserDTO> listUser = _mapper.Map<List<UserDTO>>(allUsers);
            
            List<UserDTO> users = new List<UserDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= allUsers.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < allUsers.Count())
                users = listUser.GetRange(firstIndex, request.pageSize);
            else users = listUser.GetRange(firstIndex, listUser.Count - firstIndex);
            response.status = "Success";
            response.success = true;
            response.item = headerValue;
            return response;
        }

        public async Task<Response> Login(LoginDTO user)
        {
            Response respones = new Response();
            string encodePass = CodingPassword.EncodingUTF8(user.password);
            string description = await _userRepositoryWrapper.User.CheckUserLogin(user.username, encodePass);
            if (description == null)
            {
                SeUser loginUser = await _userRepositoryWrapper.User.FindByUsername(user.username);
                TokenGenarate accessToken = new TokenGenarate(_configuration);
                SeToken token =  accessToken.GenerateToken(loginUser);
                respones.status = "200";
                respones.success = true;
                respones.item = token;
                return respones;
            }
            respones.status = "400";
            respones.success = false;
            respones.message = description;
            return respones;
        }

        public async Task<Response> Register(UserDTO reUser)
        {
            Response response = new Response();
            SeUser description = await _userRepositoryWrapper.User.FindByUsername(reUser.username);
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
            await _userRepositoryWrapper.User.Create(newUser);
            await _context.SaveChangesAsync();
            response.status = "200";
            response.success = true;
            response.item = newUser;
            return response;
        }
    }
}
