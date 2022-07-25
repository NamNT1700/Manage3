using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Allowance;

namespace Manage.Repository.IRepository
{
    public interface IHuAllowanceRepository: IRepositoryBase<HuAllowance> 
    {
        public Task<HuAllowance> FindByCode(string code);
        public Task<HuAllowance> FindById(int id);
        public Task<List<HuAllowance>> GetAll();
    }
}
