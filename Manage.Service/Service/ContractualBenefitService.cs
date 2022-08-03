using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractualBenefitService : IContractualBenefitService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContractualBenefitService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ContractualBenefitDTO contractualBenefitDto)
        {
                try
                {
                    string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                    TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                    TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                    BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                    if (tokenResponse != null)
                        return tokenResponse;
                    HuContract huContract = await _repositoryWrapper.Contract.FindByName(contractualBenefitDto.Contract);
                    if (huContract == null) return Response.NotFoundResponse("contract not exist");
                    HuWelface huWelface = await _repositoryWrapper.Welface.FindByName(contractualBenefitDto.Welface);
                    if (huWelface == null) return Response.NotFoundResponse("welface not exist");
                    HuContractWelface huContractWelface = new HuContractWelface
                    {
                        WelfaceId = huWelface.Id,
                        ContractId = huContract.Id,
                        Money = contractualBenefitDto.Money,
                    };
                    await _repositoryWrapper.ContractWelface.Create(huContractWelface);
                huContractWelface.Code = CreateCode.ContractWelfaceCode(huContractWelface.Id);
                    UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                    _mapper.Map(userInfoCreate, huContractWelface);
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
                List<HuContractWelface> huContractWelfaces = await _repositoryWrapper.ContractWelface.GetAll(request);
                List<ListContractualBenefitDTO> listContractualBenefitDTOs = _mapper.Map<List<ListContractualBenefitDTO>>(huContractWelfaces);
                return Response.SuccessResponse(listContractualBenefitDTOs);
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
                ContractualBenefitDTO huContractWelface = _mapper.Map<ContractualBenefitDTO>(huWelface);
                return Response.SuccessResponse(huContractWelface);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> Update(UpdateContractualBenefitDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(update.id);
                if (huContractWelface == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update, huContractWelface);
                await _repositoryWrapper.ContractWelface.Update(huContractWelface);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huContractWelface);
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
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                foreach (int id in ids)
                {
                    HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                    if (huContractWelface == null)
                    {
                        return Response.NotFoundResponse($"Contractwelface with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                    if (huContractWelface != null)
                        await _repositoryWrapper.ContractWelface.Delete(huContractWelface);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }
    }
}
