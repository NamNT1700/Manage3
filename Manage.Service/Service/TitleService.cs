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
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public TitleService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public async Task<BaseResponse> AddNew(TitleDTO title)
        {
            BaseResponse responce = new BaseResponse();

            HuTitle huTitle = _mapper.Map<HuTitle>(title);
            huTitle.CreatedTime = DateTime.Now;
            huTitle.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Title.Create(huTitle);
            await _context.SaveChangesAsync();
            TitleDTO hospitalDto = _mapper.Map<TitleDTO>(huTitle);
            responce.status = "200";
            responce.item = hospitalDto;
            return responce;
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuTitle> huNations = await _repositoryWrapper.Title.GetAll();
            List<ListTitleDTO> listAllwance = _mapper.Map<List<ListTitleDTO>>(huNations);
            List<ListTitleDTO> lists = new List<ListTitleDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huNations.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < huNations.Count())
                lists = listAllwance.GetRange(firstIndex, request.pageSize);
            else lists = listAllwance.GetRange(firstIndex, listAllwance.Count - firstIndex);
            response.status = "200";
            response.success = true;
            response.item = lists;
            return response;
        }

        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuTitle nation = await _repositoryWrapper.Title.FindById(id);
            if (nation != null)
            {
                TitleDTO contract = _mapper.Map<TitleDTO>(nation);
                response.item = contract;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no Title with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }



        public async Task<BaseResponse> Update(UpdateTitleDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuTitle nation = await _repositoryWrapper.Title.FindById(update.Id);
            if (nation != null)
            {
                _mapper.Map(update.updateData, nation);
                nation.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                response.status = "200";
                response.success = true;
                response.item = nation;
                return response;
            }
            response.message = "update data fail";
            response.status = "400";
            response.success = false;
            return response;
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            BaseResponse response = new BaseResponse();
            foreach (int id in ids)
            {
                HuTitle title = await _repositoryWrapper.Title.FindById(id);
                await _repositoryWrapper.Title.Delete(title);
            }
            response.message = "Delete Title";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
