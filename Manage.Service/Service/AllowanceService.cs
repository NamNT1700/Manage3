using System;
using AutoMapper;
using Manage.Common;
using Manage.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.Bank;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Service.Service
{
    public class AllowanceService : IAllowanceService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;


        public AllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }
        public async Task<BaseResponse> AddNew(AllowanceDTO allowance)
        {
            if (allowance.Name == null) return Response.DataNullResponse();
            var hAllowance = _mapper.Map<HuAllowance>(allowance);
            hAllowance.CreatedTime = DateTime.Now;
            hAllowance.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Allowance.Create(hAllowance);
            hAllowance.Code = CreateCode.AllowanceCode(hAllowance.Id);
            BaseResponse response = new BaseResponse();
            BaseResponse responce = new BaseResponse();

            HuAllowance huAllowance = _mapper.Map<HuAllowance>(allowance);
            huAllowance.CreatedTime = DateTime.Now;
            huAllowance.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Allowance.Create(huAllowance);
            huAllowance.Code = CreateCode.AllowanceCode(huAllowance.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<AllowanceDTO>(hAllowance);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            if ( request.pageNum <1 && request.pageSize<1) return Response.DataNullResponse();
            var huAllowances = await _repositoryWrapper.Allowance.GetAll(request);
            var listAllowance = _mapper.Map<List<ListAllowanceDTO>>(huAllowances);
            var lists = new List<ListAllowanceDTO>();
            var firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huAllowances.Count())
                Response.DuplicateDataResponse("no user yet");
            else if (firstIndex + request.pageSize < huAllowances.Count())
                lists = listAllowance.GetRange(firstIndex, request.pageSize);
            else lists = listAllowance.GetRange(firstIndex, listAllowance.Count - firstIndex);
            return Response.SuccessResponse(lists);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var huAllowance = await _repositoryWrapper.Allowance.FindById(id);
            if (huAllowance == null) return Response.NotFoundResponse();
            var allowance = _mapper.Map<AllowanceDTO>(huAllowance);
            return Response.SuccessResponse(allowance);
        }

        public async Task<BaseResponse> Update(UpdateAllowanceDTO update)
        {
            var allowance = await _repositoryWrapper.Allowance.FindById(update.id);
            if (allowance == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, allowance);
            allowance.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(allowance);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var allowance = await _repositoryWrapper.Allowance.FindById(id);
                if (allowance == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var allowance = await _repositoryWrapper.Allowance.FindById(id);
                if (allowance != null)
                    await _repositoryWrapper.Allowance.Delete(allowance);
            }
            return Response.SuccessResponse();
        }
    }
}
