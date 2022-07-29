using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractAllowanceService : IContractAllowanceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContractAllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ContractAllowanceDTO contractAllowanceDto)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            if (contractAllowanceDto == null)
                return Response.NotFoundResponse();
            HuContractAllowance huContractAllowance = _mapper.Map<HuContractAllowance>(contractAllowanceDto);
            await _repositoryWrapper.ContractAllowance.Create(huContractAllowance);
            huContractAllowance.Code = CreateCode.AllowanceCode(huContractAllowance.Id);
            UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
            _mapper.Map(userInfoCreate, huContractAllowance);
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
            List<HuContractAllowance> huAllowances = await _repositoryWrapper.ContractAllowance.GetAll(request);
            List<ListContractAllowanceDTO> listContractAllowances = _mapper.Map<List<ListContractAllowanceDTO>>(huAllowances);
            return Response.SuccessResponse(listContractAllowances);
        }

        public async  Task<BaseResponse> GetById(int id)
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
            ContractAllowanceDTO huContractAllowance = _mapper.Map<ContractAllowanceDTO>(huAllowance);
            return Response.SuccessResponse(huContractAllowance); throw new NotImplementedException();
        }

        public async Task<BaseResponse> Update(UpdateContractAllowanceDTO update)
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(update.Id);
            if (huContractAllowance == null)
                return Response.NotFoundResponse();
            _mapper.Map(update, huContractAllowance);
            await _repositoryWrapper.ContractAllowance.Update(huContractAllowance);
            UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
            _mapper.Map(userInfoUpdate, huContractAllowance);
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
