using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class BankService : IBankService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(BankDTO bank)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            if (bank.Name == null) return Response.DataNullResponse();
            var huBank = _mapper.Map<HuBank>(bank);
            huBank.CreatedTime = DateTime.Now;
            huBank.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Bank.Create(huBank);
            huBank.Code = CreateCode.AllowanceCode(huBank.Id);
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
            List<HuBank> huAllowances = await _repositoryWrapper.Bank.GetAll(request);
            List<ListBankDTO> listAllowance = _mapper.Map<List<ListBankDTO>>(huAllowances);
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
            var huBank = await _repositoryWrapper.Bank.FindById(id);
            if (huBank == null) return Response.NotFoundResponse();
            var bank = _mapper.Map<BankDTO>(huBank);
            return Response.SuccessResponse(bank);
        }
        public async Task<BaseResponse> Update(UpdateBankDTO update)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuBank bank = await _repositoryWrapper.Bank.FindById(update.Id);
            if (bank == null) return Response.NotFoundResponse();
            _mapper.Map(update.updateData, bank);
            UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
            _mapper.Map(userInfoUpdate, bank);
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(bank);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            foreach (var id in ids)
            {
                var bank = await _repositoryWrapper.Bank.FindById(id);
                if (bank == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var bank = await _repositoryWrapper.Bank.FindById(id);
                if (bank != null)
                    await _repositoryWrapper.Bank.Delete(bank);
            }
            return Response.SuccessResponse();
        }
    }
}
