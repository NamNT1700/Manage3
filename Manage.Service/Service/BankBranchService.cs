using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class BankBranchService : IBankBranchService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankBranchService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(BankBranchDTO bankBranch)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            if (bankBranch.BankName == null || bankBranch.Address == null)
                return Response.DataNullResponse();
            HuBankBranch huBankBranch = _mapper.Map<HuBankBranch>(bankBranch);
            await _repositoryWrapper.BankBranch.Create(huBankBranch);
            huBankBranch.Code = CreateCode.BankBranchCode(huBankBranch.Id);
            UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
            _mapper.Map(userInfoCreate, bankBranch);
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
            if (request.pageNum < 1 || request.pageSize < 1)
                return Response.NotFoundResponse();
            if (request.pageNum > request.pageSize)
                return Response.NotFoundResponse();
            List<HuBankBranch> huBankBranches = await _repositoryWrapper.BankBranch.GetAll(request);
            List<ListBankBranchDTO> listBankBranchDTOs = _mapper.Map<List<ListBankBranchDTO>>(huBankBranches);
            return Response.SuccessResponse(listBankBranchDTOs);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(id);
            if (huBankBranch == null)
                return Response.NotFoundResponse();
            BankBranchDTO bankBranch = _mapper.Map<BankBranchDTO>(huBankBranch);
            return Response.SuccessResponse(bankBranch);
        }

        public async Task<BaseResponse> Update(UpdateBankBranchDTO update)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(update.Id);
            if (huBankBranch == null)
                return Response.NotFoundResponse();
            _mapper.Map(update.updateData, huBankBranch);
            await _repositoryWrapper.BankBranch.Update(huBankBranch);
            UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
            _mapper.Map(userInfoUpdate, huBankBranch);
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
