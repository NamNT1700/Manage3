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

        public async Task<BaseResponse> AddNew(BankDTO bank)
        public async Task<BaseResponse> AddNewBank(BankDTO bank)
        {
            BaseResponse responce = new BaseResponse();
            HuBank huBank = _mapper.Map<HuBank>(bank);
            huBank.CreatedTime = DateTime.Now;
            huBank.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Bank.Create(huBank);
            huBank.Code = CreateCode.AllowanceCode(huBank.Id);
            await _context.SaveChangesAsync();
            BankDTO bankDto = _mapper.Map<BankDTO>(huBank);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuBank> huBanks = await _repositoryWrapper.Bank.GetAll(request);
            List<ListBankDTO> listBankDtos = _mapper.Map<List<ListBankDTO>>(huBanks);
            List<ListBankDTO> list = new List<ListBankDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huBanks.Count())
                response = Response.DuplicateDataResponse("no user yet");
            if (firstIndex + request.pageSize < huBanks.Count())
                list = listBankDtos.GetRange(firstIndex, request.pageSize);
            else list = listBankDtos.GetRange(firstIndex, listBankDtos.Count - firstIndex);
            return Response.SuccessResponse(list);
        }

            response.status = "200";
            response.success = true;
            response.item = listBankDtos;
            return response;
        }
        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuBank huBank = await _repositoryWrapper.Bank.FindById(id);
            if (huBank != null)
            {
                BankDTO bank = _mapper.Map<BankDTO>(huBank);
                return Response.SuccessResponse(bank);
            }
            return Response.NotFoundResponse();
        }
        public async Task<BaseResponse> Update(UpdateBankDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuBank bank = await _repositoryWrapper.Bank.FindById(update.Id);
            if (bank != null)
            {
                _mapper.Map(update.updateData, bank);
                bank.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Response.SuccessResponse(bank);
            }
            return Response.DataNullResponse();
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            BaseResponse response = new BaseResponse();
            foreach (int id in ids)
            {
                HuBank bank = await _repositoryWrapper.Bank.FindById(id);
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
