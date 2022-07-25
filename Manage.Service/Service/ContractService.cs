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

        public async Task<Response> AddNew(ContractDTO contract)
        {
            Response responce = new Response();

            HuContract huContract = _mapper.Map<HuContract>(contract);
            huContract.CreatedTime = DateTime.Now;
            huContract.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Contract.Create(huContract);
            await _context.SaveChangesAsync();
            ContractDTO bankDto = _mapper.Map<ContractDTO>(huContract);
            responce.status = "200";
            responce.item = bankDto;
            return responce;
        }



        public async Task<Response> GetAll(BaseRequest request)
        {
            Response response = new Response();
            List<HuContract> huContracts = await _repositoryWrapper.Contract.GetAll();
            List<ListContractDTO> listAllwance = _mapper.Map<List<ListContractDTO>>(huContracts);
            List<ListContractDTO> lists = new List<ListContractDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huContracts.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < huContracts.Count())
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
            HuContract huContract = await _repositoryWrapper.Contract.FindById(id);
            if (huContract != null)
            {
                ContractDTO contract = _mapper.Map<ContractDTO>(huContract);
                response.item = contract;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no contract with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }



        public async Task<Response> Update(UpdateContractDTO update)
        {
            Response response = new Response();
            HuContract contract = await _repositoryWrapper.Contract.FindById(update.Id);
            if (contract != null)
            {
                _mapper.Map(update.updateData, contract);
                contract.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                response.status = "200";
                response.success = true;
                response.item = contract;
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
                HuContract bank = await _repositoryWrapper.Contract.FindById(id);
                await _repositoryWrapper.Contract.Delete(bank);
            }
            response.message = "Delete contract";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
