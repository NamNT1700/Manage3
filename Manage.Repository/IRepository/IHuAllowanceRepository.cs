using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Allowance;
using Manage.Common;

namespace Manage.Repository.IRepository
{
    public interface IHuAllowanceRepository: IRepositoryBase<HuAllowance> 
    {
        Task<HuAllowance> FindByName(string name);
        Task<List<HuAllowance>> GetAll(BaseRequest baseRequest);
    }
}
