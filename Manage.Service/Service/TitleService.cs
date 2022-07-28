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

namespace Manage.Service.Service
{
    public class TitleService : ITitleService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;


        public TitleService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
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
            var titles = await _repositoryWrapper.Title.GetAll(request);
            var listTitles = _mapper.Map<List<ListTitleDTO>>(titles);
            var lists = new List<ListTitleDTO>();
            var firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= titles.Count())
                Response.DuplicateDataResponse("no user yet");
            else if(firstIndex + request.pageSize < titles.Count())
                lists = listTitles.GetRange(firstIndex, request.pageSize);
            else lists = listTitles.GetRange(firstIndex, listTitles.Count - firstIndex);
            return Response.SuccessResponse(lists);
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
