using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Contract;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Repository.Base.Repository;
using Manage.Service.IService;

namespace Manage.Service.Service
{
    public class ContractService : IContractService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public ContractService(IMapper mapper, IRepositoryWrapper repositoryWapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWapper;
            _context = context;
        }

        public async Task<BaseResponse> AddNew(ContractDTO contract)
        {
            BaseResponse responce = new BaseResponse();

            HuContract huContract = _mapper.Map<HuContract>(contract);
            huContract.CreatedTime = DateTime.Now;
            huContract.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Contract.Create(huContract);
            huContract.Code = CreateCode.AllowanceCode(huContract.Id);
            await _context.SaveChangesAsync();
            ContractDTO bankDto = _mapper.Map<ContractDTO>(huContract);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuContract> huContracts = await _repositoryWrapper.Contract.GetAll(request);
            List<HuContract> huContracts = await _repositoryWrapper.Contract.GetAll();
            List<ListContractDTO> listAllwance = _mapper.Map<List<ListContractDTO>>(huContracts);
            List<ListContractDTO> lists = new List<ListContractDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huContracts.Count())
                response = Response.DuplicateDataResponse("no user yet");
            if (firstIndex + request.pageSize < huContracts.Count())
                lists = listAllwance.GetRange(firstIndex, request.pageSize);
            else lists = listAllwance.GetRange(firstIndex, listAllwance.Count - firstIndex);
            return Response.SuccessResponse(lists);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuContract huContract = await _repositoryWrapper.Contract.FindById(id);
            if (huContract != null)
            {
                ContractDTO contract = _mapper.Map<ContractDTO>(huContract);
                return Response.SuccessResponse(response);
            }
            return Response.NotFoundResponse();
        }



        public async Task<BaseResponse> Update(UpdateContractDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuContract contract = await _repositoryWrapper.Contract.FindById(update.Id);
            if (contract != null)
            {
                _mapper.Map(update.updateData, contract);
                contract.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Response.SuccessResponse(response);
            }
            return Response.DataNullResponse();
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            BaseResponse response = new BaseResponse();
            foreach (int id in ids)
            {
                HuContract bank = await _repositoryWrapper.Contract.FindById(id);
                await _repositoryWrapper.Contract.Delete(bank);
            }
            return Response.SuccessResponse();
        }
    }
}
