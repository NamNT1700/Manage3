using System;
using AutoMapper;
using Manage.Common;
using Manage.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Service.Service
{
    public class AllowanceService :IAllowanceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context ;
        

        public AllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }
        public async Task<BaseResponse> AddNew(AllowanceDTO allowance)
        {
            BaseResponse responce = new BaseResponse();

            HuAllowance huAllowance = _mapper.Map<HuAllowance>(allowance);
            huAllowance.CreatedTime = DateTime.Now;
            huAllowance.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Allowance.Create(huAllowance);
            await _context.SaveChangesAsync();
            AllowanceDTO allowanceDTO = _mapper.Map<AllowanceDTO>(huAllowance);
            responce.status = "200";
            responce.item = allowanceDTO;
            return responce;
        }

       

        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuAllowance> huAllwances = await _repositoryWrapper.Allowance.GetAll(request);
            List<ListAllowanceDTO> listAllwance =  _mapper.Map<List<ListAllowanceDTO>>(huAllwances);
            List<ListAllowanceDTO> lists = new List<ListAllowanceDTO>();
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

        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindById(id);
            if (huAllowance != null)
            {
                AllowanceDTO allowance = _mapper.Map<AllowanceDTO>(huAllowance);
                response.item = allowance;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no allwance with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }

        public async Task<BaseResponse> Update(UpdateAllowanceDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(update.id);
            if(allowance!=null)
            {
                _mapper.Map(update.updateData, allowance);
                allowance.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                response.status = "200";
                response.success = true;
                response.item = allowance;
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
                HuAllowance allwance = await _repositoryWrapper.Allowance.FindById(id);
                await _repositoryWrapper.Allowance.Delete(allwance);
            }
            response.message = "Delete allwance";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
