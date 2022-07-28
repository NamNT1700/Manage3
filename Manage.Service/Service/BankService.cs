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
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;


        public BankService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public async Task<BaseResponse> AddNew(BankDTO bank)
        public async Task<BaseResponse> AddNewBank(BankDTO bank)
        {
            if (bank.Name == null) return Response.DataNullResponse();
            var huBank = _mapper.Map<HuBank>(bank);
            huBank.CreatedTime = DateTime.Now;
            huBank.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Bank.Create(huBank);
            huBank.Code = CreateCode.AllowanceCode(huBank.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<BankDTO>(huBank);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            var huBanks = await _repositoryWrapper.Bank.GetAll(request);
            var listBankDots = _mapper.Map<List<ListBankDTO>>(huBanks);
            var list = new List<ListBankDTO>();
            var firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huBanks.Count())
                Response.DuplicateDataResponse("no user yet");
            else if (firstIndex + request.pageSize < huBanks.Count())
                list = listBankDots.GetRange(firstIndex, request.pageSize);
            else list = listBankDots.GetRange(firstIndex, listBankDots.Count - firstIndex);
            return Response.SuccessResponse(list);
        }

            response.status = "200";
            response.success = true;
            response.item = listBankDtos;
            return response;
        }
        public async Task<BaseResponse> GetById(int id)
        {
            var huBank = await _repositoryWrapper.Bank.FindById(id);
            if (huBank == null) return Response.NotFoundResponse();
            var bank = _mapper.Map<BankDTO>(huBank);
            return Response.SuccessResponse(bank);
        }
        public async Task<BaseResponse> Update(UpdateBankDTO update)
        {
            var bank = await _repositoryWrapper.Bank.FindById(update.Id);
            if (bank == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, bank);
            bank.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(bank);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var bank = await _repositoryWrapper.Bank.FindById(id);
                if (bank == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var bank = await _repositoryWrapper.Bank.FindById(id);
                if (bank != null)
                    await _repositoryWrapper.Bank.Delete(bank);
            }
            return Response.SuccessResponse();
        }

        public async Task<BaseResponse> AddNewBranch(BankBranchDTO bankBranch)
        {
            BaseResponse response = new BaseResponse();
            HuBank bank = await _repositoryWrapper.Bank.FindByName(bankBranch.BankName);
            if (bank == null)
            {
                response.message = "Bank doesnt exilt";
                response.status = "400";
                response.success = false;
            }               
            HuBankBranch huBankBranch = _mapper.Map<HuBankBranch>(bankBranch);
            huBankBranch.BankId = bank.Id;
            response.message = "success";
            response.status = "200";
            response.success = true;
            return response;

        }
    }
}
