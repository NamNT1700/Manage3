using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuBankRepository : RepositoryBase<HuBank>, IHuBankRepository
    {
        public HuBankRepository(DatabaseContext context) : base(context)
        {
           
        }
        public async Task<HuBank> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
        public async Task<List<ListBankBranch>> FindAllBankById(List<ListBankBranch> listBankBranches)
        {
            foreach (ListBankBranch listBankBranch in listBankBranches)
            {
                HuBank huBank= await FindById(listBankBranch.BankID);
                listBankBranch.Bankname = huBank.Name;
            }
            return listBankBranches;
        }
    }
}
