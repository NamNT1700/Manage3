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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public ContractService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(ContractDTO contract)
        {
            if (contract.Name == null) return Response.DataNullResponse();
            var huContract = _mapper.Map<HuContract>(contract);
            huContract.CreatedTime = DateTime.Now;
            huContract.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Contract.Create(huContract);
            huContract.Code = CreateCode.AllowanceCode(huContract.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<ContractDTO>(huContract);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            List<HuContract> huContracts = await _repositoryWrapper.Contract.GetAll(request);
            List<ListContractDTO> listAllwance = _mapper.Map<List<ListContractDTO>>(huContracts);
            return Response.SuccessResponse(listAllwance);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var response = new BaseResponse();
            var huContract = await _repositoryWrapper.Contract.FindById(id);
            if (huContract == null) return Response.NotFoundResponse();
            _mapper.Map<ContractDTO>(huContract);
            return Response.SuccessResponse(response);
        }



        public async Task<BaseResponse> Update(UpdateContractDTO update)
        {
            var response = new BaseResponse();
            var contract = await _repositoryWrapper.Contract.FindById(update.Id);
            if (contract == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, contract);
            contract.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(response);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {

            foreach (var id in ids)
            {
                var contract = await _repositoryWrapper.Contract.FindById(id);
                if (contract == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var contract = await _repositoryWrapper.Contract.FindById(id);
                if (contract != null)
                    await _repositoryWrapper.Contract.Delete(contract);
            }
            return Response.SuccessResponse();
        }
    }
}
