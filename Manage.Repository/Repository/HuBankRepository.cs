using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Bank;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuBankRepository : RepositoryBase<HuBank>, IHuBankRepository
    {
        public HuBankRepository(DatabaseContext context) : base(context)
        {
           
        }

        public async Task<string> CheckData(BankDTO bank)
        {
            HuBank huBank = await FindByCode(bank.Code);
            if (huBank != null)
                return "code already exist";
            huBank = await FindById(bank.Id);
            if (huBank != null)
                return "id already exist";
            return null;
        }
        public async Task<List<HuBank>> GetAll()
        {
            return await Task.Run(() => FindAll().OrderBy(a => a.Id).ToList());
        }
    }
}
