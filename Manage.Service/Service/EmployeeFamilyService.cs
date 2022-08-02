using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class EmployeeFamilyService : IEmployeeFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeFamilyService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(EmployeeFamilyDTO employeeFamilyDto)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployeeFamily huEmployeeFamily = _mapper.Map<HuEmployeeFamily>(employeeFamilyDto);
                await _repositoryWrapper.EmployeeFamily.Create(huEmployeeFamily);
                huEmployeeFamily.Code = CreateCode.EmployeeCode(huEmployeeFamily.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huEmployeeFamily);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
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
                HuEmployeeFamily huEmployeeFamily = await _repositoryWrapper.EmployeeFamily.FindById(id);
                if (huEmployeeFamily == null)
                    return Response.NotFoundResponse();
                EmployeeFamilyDTO employeeFamilyDTO = _mapper.Map<EmployeeFamilyDTO>(huEmployeeFamily);
                return Response.SuccessResponse(employeeFamilyDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> Update(UpdateEmployeeFamilyDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployeeFamily huEmployeeFamily = await _repositoryWrapper.EmployeeFamily.FindById(update.id);
                if (huEmployeeFamily == null)
                    return Response.NotFoundResponse();
                huEmployeeFamily = _mapper.Map<HuEmployeeFamily>(update.updateData);
                await _repositoryWrapper.EmployeeFamily.Update(huEmployeeFamily);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huEmployeeFamily);
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
                    HuEmployeeFamily huEmployeeFamily = await _repositoryWrapper.EmployeeFamily.FindById(id);
                    if (huEmployeeFamily == null)
                    {
                        return Response.NotFoundResponse();
                    }
                }
                foreach (int id in ids)
                {
                    HuEmployeeFamily huEmployeeFamily = await _repositoryWrapper.EmployeeFamily.FindById(id);
                    if (huEmployeeFamily != null)
                        await _repositoryWrapper.EmployeeFamily.Delete(huEmployeeFamily);
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
