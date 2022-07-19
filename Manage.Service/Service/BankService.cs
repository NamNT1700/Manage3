using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Allwance;
using Manage.Model.DTO.Bank;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Service.IService;

namespace Manage.Service.Service
{
    public class BankService : IBankService
    {
        private IMapper _mapper;
        private IHuBankRepositoryWrapper _bankRepositoryWrapper;
        private DatabaseContext _context;


        public BankService(IMapper mapper, IHuBankRepositoryWrapper bankRepositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _bankRepositoryWrapper = bankRepositoryWrapper;
            _context = context;
        }

        public async Task<Response> AddNew(BankDTO bank)
        {
            Response responce = new Response();
            string message = await _bankRepositoryWrapper.Bank.CheckData(bank);
            if (message != null)
            {
                responce.message = message;
                responce.status = "400";
                return responce;
            }

            HuBank huBank = _mapper.Map<HuBank>(bank);
            await _bankRepositoryWrapper.Bank.Create(huBank);
            await _context.SaveChangesAsync();
            BankDTO bankDto = _mapper.Map<BankDTO>(huBank);
            responce.status = "200";
            responce.item = bankDto;
            return responce;
        }



        public async Task<Response> GetAll(Request request)
        {
            Response response = new Response();
            List<HuBank> huBanks = await _bankRepositoryWrapper.Bank.GetAll();
            List<ListBankDTO> listAllwance = _mapper.Map<List<ListBankDTO>>(huBanks);
            List<ListBankDTO> lists = new List<ListBankDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huBanks.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < huBanks.Count())
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
            HuBank huBank = await _bankRepositoryWrapper.Bank.FindById(id);
            if (huBank != null)
            {
                AllwanceDTO allwance = _mapper.Map<AllwanceDTO>(huBank);
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

       

        public async Task<Response> Update(UpdateBankDTO update)
        {
            Response response = new Response();
            HuBank bank = await _bankRepositoryWrapper.Bank.FindById(update.Id);
            if (bank != null)
            {
                _mapper.Map(update.updateData, bank);
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
                HuBank bank = await _bankRepositoryWrapper.Bank.FindById(id);
                await _bankRepositoryWrapper.Bank.Delete(bank);
            }
            response.message = "Delete allwance";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
