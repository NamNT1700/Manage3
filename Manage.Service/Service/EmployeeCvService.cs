using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.EmployeeCv;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class EmployeeCvService : IEmployeeCvService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeCvService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(EmployeeCvDTO employeeCvDto)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                OtherList otherList = await _repositoryWrapper.OtherList.FindByName(employeeCvDto.Gender);
                if (otherList == null) return Response.NotFoundResponse("invalid gender");
                otherList = await _repositoryWrapper.OtherList.FindByName(employeeCvDto.Religion);
                if (otherList == null) return Response.NotFoundResponse("invalid religion");
                HuEmployeeCv huEmployeeCv = _mapper.Map<HuEmployeeCv>(employeeCvDto);
                await _repositoryWrapper.EmployeeCv.Create(huEmployeeCv);
                huEmployeeCv.Code = CreateCode.EmployeeCode(huEmployeeCv.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huEmployeeCv);
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
                HuEmployeeCv huEmployeeCv = await _repositoryWrapper.EmployeeCv.FindById(id);
                if (huEmployeeCv == null)
                    return Response.NotFoundResponse();
                EmployeeCvDTO employeeCvDTO = _mapper.Map<EmployeeCvDTO>(huEmployeeCv);
                return Response.SuccessResponse(employeeCvDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateEmployeeCvDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployeeCv huEmployeeCv = await _repositoryWrapper.EmployeeCv.FindById(update.id);
                if (huEmployeeCv == null)
                    return Response.NotFoundResponse();
                 _mapper.Map(update.updateData, huEmployeeCv);
                await _repositoryWrapper.EmployeeCv.Update(huEmployeeCv);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huEmployeeCv);
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
                    HuEmployeeCv huEmployeeCv = await _repositoryWrapper.EmployeeCv.FindById(id);
                    if (huEmployeeCv == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuEmployeeCv huEmployeeCv = await _repositoryWrapper.EmployeeCv.FindById(id);
                    if (huEmployeeCv != null)
                        await _repositoryWrapper.EmployeeCv.Delete(huEmployeeCv);
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
