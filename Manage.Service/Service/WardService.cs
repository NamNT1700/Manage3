using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.DTO.Ward;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class WardService : IWardService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WardService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(WardDTO wardDto)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuDistrict huDistrict = await _repositoryWrapper.District.FindByName(wardDto.Name);
                if (huDistrict == null) return Response.NotFoundResponse();
                HuWard huWard = _mapper.Map<HuWard>(wardDto);
                huWard.DistricId = huDistrict.Id;
                await _repositoryWrapper.Ward.Create(huWard);
                huWard.Code = CreateCode.WardCode(huWard.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huWard);
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
                List<HuWard> huWards = await _repositoryWrapper.Ward.GetAll(request);
                List<ListWard> listWards = _mapper.Map<List<ListWard>>(huWards);
                listWards = await _repositoryWrapper.District.FindAllDistrictById(listWards);
                List<ListWardDTO> listProvinceDtos = _mapper.Map<List<ListWardDTO>>(listWards);
                return Response.SuccessResponse(listProvinceDtos);
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
                HuWard huWard = await _repositoryWrapper.Ward.FindById(id);
                if (huWard == null)
                    return Response.NotFoundResponse();
                HuDistrict huDistrict = await _repositoryWrapper.District.FindById(huWard.DistricId);
                WardDTO ward = _mapper.Map<WardDTO>(huWard);
                ward.DistrictName = huDistrict.Name;
                return Response.SuccessResponse(ward);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateWardDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuWard huWard = await _repositoryWrapper.Ward.FindById(update.Id);
                if (huWard == null)
                    return Response.NotFoundResponse();
                HuDistrict huDistrict = await _repositoryWrapper.District.FindByName(update.updateData.Districname);
                _mapper.Map(update.updateData, huWard);
                huWard.DistricId = huDistrict.Id;
                await _repositoryWrapper.Ward.Update(huWard);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huWard);
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
                    HuWard ward = await _repositoryWrapper.Ward.FindById(id);
                    if (ward == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuWard ward = await _repositoryWrapper.Ward.FindById(id);
                    if (ward != null)
                        await _repositoryWrapper.Ward.Delete(ward);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }
        public async Task<BaseResponse> ChangeStatus(int id)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuWard huWard = await _repositoryWrapper.Ward.FindById(id);
                if (huWard == null)
                    return Response.NotFoundResponse();
                huWard.Activeflg = Tools.ChangeStatus(huWard.Activeflg);
                await _repositoryWrapper.Ward.Update(huWard);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huWard);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }

        }

    }
}
