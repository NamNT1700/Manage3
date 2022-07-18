using AutoMapper;
using Manage.Common;
using Manage.Model.DTO.Allwance;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.Models;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class AllwanceService : IAllwanceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context ;
        

        public AllwanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }
        public async Task<Response> AddNew(AllwanceDTO allwance)
        {
            Response responce = new Response();
            string message = await _repositoryWrapper.Allwance.CheckData(allwance);
            if (message != null)
            {
                responce.message = message;
                responce.status = "400";
                return responce;
            }

            HuAllwance huAllwance = _mapper.Map<HuAllwance>(allwance);
            await _repositoryWrapper.Allwance.Create(huAllwance);
            await _repositoryWrapper.SaveAsync();
            AllwanceDTO allwanceDTO = _mapper.Map<AllwanceDTO>(huAllwance);
            responce.status = "200";
            responce.item = allwanceDTO;
            return responce;
        }

       

        public async Task<Response> GetAll(Request request)
        {
            Response response = new Response();
            List<HuAllwance> huAllwances = await _repositoryWrapper.Allwance.GetAll();
            List<ListAllwanceDTO> listAllwance =  _mapper.Map<List<ListAllwanceDTO>>(huAllwances);
            List<ListAllwanceDTO> lists = new List<ListAllwanceDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huAllwances.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < huAllwances.Count())
                lists = listAllwance.GetRange(firstIndex, request.pageSize);
            else lists = listAllwance.GetRange(firstIndex, listAllwance.Count - firstIndex);
            response.status = "200";
            response.success = true;
            response.item = lists;
            return response;
        }

        public async Task<Response> GetById(int id)
        {
            Response response = new Response();
            HuAllwance huAllwance = await _repositoryWrapper.Allwance.FindById(id);
            if (huAllwance != null)
            {
                AllwanceDTO allwance = _mapper.Map<AllwanceDTO>(huAllwance);
                response.item = allwance;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no allwance with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }

        public async Task<Response> Update(UpdateDTO update)
        {
            Response response = new Response();
            HuAllwance allwance = await _repositoryWrapper.Allwance.FindById(update.id);
            if(allwance!=null)
            {
                _mapper.Map(update.updateData, allwance);
                await _repositoryWrapper.SaveAsync();
                response.status = "200";
                response.success = true;
                response.item = allwance;
                return response;
            }
            response.message = "update data fail";
            response.status = "400";
            response.success = false;
            return response;
        }
        public async Task<Response> Delete(List<int> ids)
        {
            Response response = new Response();
            foreach (int id in ids)
            {
                HuAllwance allwance = await _repositoryWrapper.Allwance.FindById(id);
                await _repositoryWrapper.Allwance.Delete(allwance);
            }
            response.message = "Delete allwance";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
