using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Title;
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
            if (title.Name == null) return Response.DataNullResponse();
            var huTitle = _mapper.Map<HuTitle>(title);
            huTitle.CreatedTime = DateTime.Now;
            huTitle.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Title.Create(huTitle);
            huTitle.Code = CreateCode.AllowanceCode(huTitle.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<TitleDTO>(huTitle);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            List<HuTitle> huNations = await _repositoryWrapper.Title.GetAll(request);
            List<ListTitleDTO> listAllwance = _mapper.Map<List<ListTitleDTO>>(huNations);
            return Response.SuccessResponse(listAllwance);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var response = new BaseResponse();
            var nation = await _repositoryWrapper.Title.FindById(id);
            if (nation == null) return Response.NotFoundResponse();
            _mapper.Map<TitleDTO>(nation);
            return Response.SuccessResponse(response);
        }



        public async Task<BaseResponse> Update(UpdateTitleDTO update)
        {
            var response = new BaseResponse();
            var nation = await _repositoryWrapper.Title.FindById(update.Id);
            if (nation == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, nation);
            nation.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(response);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var title = await _repositoryWrapper.Title.FindById(id);
                if (title == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var title = await _repositoryWrapper.Title.FindById(id);
                if (title != null)
                    await _repositoryWrapper.Title.Delete(title);
            }
            return Response.SuccessResponse();
        }
    }
}
