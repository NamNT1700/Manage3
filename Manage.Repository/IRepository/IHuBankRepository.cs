using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Bank;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuBankRepository : IRepositoryBase<HuBank>
    {
        public Task<string> CheckData(BankDTO bank);
        public Task<HuBank> FindByCode(string code);
        public Task<HuBank> FindById(int id);
        public Task<List<HuBank>> GetAll();
    }
}
