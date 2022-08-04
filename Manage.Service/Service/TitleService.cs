using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Title;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class TitleService : ITitleService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TitleService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(TitleDTO title)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuTitle huTitle = _mapper.Map<HuTitle>(title);
                await _repositoryWrapper.Title.Create(huTitle);
                huTitle.Code = CreateCode.TitleCode(huTitle.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huTitle);
                await _context.SaveChangesAsync();
                _mapper.Map<TitleDTO>(huTitle);
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
                List<HuTitle> huTitles = await _repositoryWrapper.Title.GetAll(request);
                List<ListTitleDTO> listTitleDTOs = _mapper.Map<List<ListTitleDTO>>(huTitles);
                return Response.SuccessResponse(listTitleDTOs);
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
                HuTitle huTitle = await _repositoryWrapper.Title.FindById(id);
                if (huTitle == null) return Response.NotFoundResponse();
                TitleDTO titleDTO = _mapper.Map<TitleDTO>(huTitle);
                return Response.SuccessResponse(titleDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }



        public async Task<BaseResponse> Update(UpdateTitleDTO update)
        {
            try
            {
                string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuTitle huTitle = await _repositoryWrapper.Title.FindById(update.Id);
                if (huTitle == null) return Response.DataNullResponse();
                _mapper.Map(update.updateData, huTitle);
                await _repositoryWrapper.Title.Update(huTitle);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huTitle);
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
                    HuTitle title = await _repositoryWrapper.Title.FindById(id);
                    if (title == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuTitle title = await _repositoryWrapper.Title.FindById(id);
                    if (title != null)
                        await _repositoryWrapper.Title.Delete(title);
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
