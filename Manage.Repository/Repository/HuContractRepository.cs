using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Contract;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuContractRepository : RepositoryBase<HuContract>, IHuContractRepository
    {
        public HuContractRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<string> CheckData(ContractDTO contract)
        {
            HuContract huContract = await FindByCode(contract.Code);
            if (huContract != null)
                return "code already exist";
            huContract = await FindById(contract.Id);
            if (huContract != null)
                return "id already exist";
            return null;
        }
        public async Task<List<HuContract>> GetAll()
        {
            return await Task.Run(() => FindAll().OrderBy(a => a.Id).ToList());
        }
    }
}
