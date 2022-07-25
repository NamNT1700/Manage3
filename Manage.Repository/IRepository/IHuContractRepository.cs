using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Contract;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuContractRepository : IRepositoryBase<HuContract>
    {
        public Task<HuContract> FindByCode(string code);
        public Task<HuContract> FindById(int id);
        public Task<List<HuContract>> GetAll();
    }
}
