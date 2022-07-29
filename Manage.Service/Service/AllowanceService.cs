using System;
using AutoMapper;
using Manage.Common;
using Manage.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.Bank;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Manage.Model.DTO.User;

namespace Manage.Service.Service
{
    public class AllowanceService : IAllowanceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(AllowanceDTO allowance)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            if (allowance.Name == null)
                return Response.DataNullResponse();
            HuAllowance huAllowance = _mapper.Map<HuAllowance>(allowance);
            await _repositoryWrapper.Allowance.Create(huAllowance);
            huAllowance.Code = CreateCode.AllowanceCode(huAllowance.Id);
            UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
            _mapper.Map(userInfoCreate, huAllowance);
            await _context.SaveChangesAsync();
            return Response.SuccessResponse();
        } 
        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            if (request.pageNum <1 || request.pageSize<1)
                return Response.NotFoundResponse();
            if(request.pageNum > request.pageSize)
                return Response.NotFoundResponse();
            List<HuAllowance> huAllowances = await _repositoryWrapper.Allowance.GetAll(request);
            List<ListAllowanceDTO> listAllowance = _mapper.Map<List<ListAllowanceDTO>>(huAllowances);
            return Response.SuccessResponse(listAllowance);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindById(id);
            if (huAllowance == null)
                return Response.NotFoundResponse();
            AllowanceDTO allowance = _mapper.Map<AllowanceDTO>(huAllowance);
            return Response.SuccessResponse(allowance);
        }

        public async Task<BaseResponse> Update(UpdateAllowanceDTO update)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(update.id);
            if (allowance == null)
                return Response.NotFoundResponse();
            _mapper.Map(update.updateData, allowance);
            await _repositoryWrapper.Allowance.Update(allowance);
            UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
            _mapper.Map(userInfoUpdate, allowance);
            await _context.SaveChangesAsync();
            return Response.SuccessResponse();
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
                HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(id);
                if (allowance == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (int id in ids)
            {
                HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(id);
                if (allowance != null)
                    await _repositoryWrapper.Allowance.Delete(allowance);
            }
            return Response.SuccessResponse();
        }
    }
}
