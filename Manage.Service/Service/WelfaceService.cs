using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Welface;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.User;
using Manage.Model.Models;

namespace Manage.Service.Service
{
    public class WelfaceService: IWelfaceService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WelfaceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(WelfaceDTO welfaceDto)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuWelface huWelface = _mapper.Map<HuWelface>(welfaceDto);
                await _repositoryWrapper.Welface.Create(huWelface);
                huWelface.Code = CreateCode.AllowanceCode(huWelface.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                if (request.pageNum < 1 || request.pageSize < 1)
                    return Response.NotFoundResponse();
                if (request.pageNum > request.pageSize)
                    return Response.NotFoundResponse();
                List<HuWelface> huWelfaces = await _repositoryWrapper.Welface.GetAll(request);
                List<ListWelfaceDTO> listWelfaceDTOs = _mapper.Map<List<ListWelfaceDTO>>(huWelfaces);
                return Response.SuccessResponse(listWelfaceDTOs);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> GetById(int id)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuWelface huWelface = await _repositoryWrapper.Welface.FindById(id);
                if (huWelface == null)
                    return Response.NotFoundResponse();
                WelfaceDTO welfaceDTO = _mapper.Map<WelfaceDTO>(huWelface);
                return Response.SuccessResponse(welfaceDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }

        public async Task<BaseResponse> Update(UpdateWelfaceDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuWelface welface = await _repositoryWrapper.Welface.FindById(update.Id);
                if (welface == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, welface);
                await _repositoryWrapper.Welface.Update(welface);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, welface);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Delete(List<int> ids)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            foreach (int id in ids)
            {
                HuWelface welface = await _repositoryWrapper.Welface.FindById(id);
                if (welface == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (int id in ids)
            {
                HuWelface welface = await _repositoryWrapper.Welface.FindById(id);
                if (welface != null)
                    await _repositoryWrapper.Welface.Delete(welface);
            }
            return Response.SuccessResponse();
        }
    }
}
