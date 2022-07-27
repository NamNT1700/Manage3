using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;

namespace Manage.Service.Service
{
    public class BankService : IBankService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public BankService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public async Task<Response> AddNewBank(BankDTO bank)
        {
            Response responce = new Response();
            HuBank huBank = _mapper.Map<HuBank>(bank);
            huBank.CreatedTime = DateTime.Now;
            huBank.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Bank.Create(huBank);
            await _context.SaveChangesAsync();
            BankDTO bankDto = _mapper.Map<BankDTO>(huBank);
            responce.status = "200";
            responce.item = bankDto;
            return responce;
        }



        public async Task<Response> GetAll(BaseRequest request)
        {
            Response response = new Response();
            List<HuBank> huBanks = await _repositoryWrapper.Bank.GetAll(request);
            List<ListBankDTO> listBankDtos = _mapper.Map<List<ListBankDTO>>(huBanks);
            response.status = "200";
            response.success = true;
            response.item = listBankDtos;
            return response;
        }
        public async Task<Response> GetById(int id)
        {
            Response response = new Response();
            HuBank huBank = await _repositoryWrapper.Bank.FindById(id);
            if (huBank != null)
            {
                BankDTO bank = _mapper.Map<BankDTO>(huBank);
                response.item = bank;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no bank with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }

       

        public async Task<Response> Update(UpdateBankDTO update)
        {
            Response response = new Response();
            HuBank bank = await _repositoryWrapper.Bank.FindById(update.Id);
            if (bank != null)
            {
                _mapper.Map(update.updateData, bank);
                bank.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                response.status = "200";
                response.success = true;
                response.item = bank;
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
                HuBank bank = await _repositoryWrapper.Bank.FindById(id);
                await _repositoryWrapper.Bank.Delete(bank);
            }
            response.message = "Delete bank";
            response.status = "200";
            response.success = true;
            return response;
        }

        public async Task<Response> AddNewBranch(BankBranchDTO bankBranch)
        {
            Response response = new Response();
            HuBank bank = await _repositoryWrapper.Bank.FindByName(bankBranch.BankName);
            if (bank == null) return response;
            HuBankBranch huBankBranch = _mapper.Map<HuBankBranch>(bankBranch);
            huBankBranch.BankId = bank.Id;
            response.message = "success";
            response.status = "200";
            response.success = true;
            return response;

        }
    }
}
