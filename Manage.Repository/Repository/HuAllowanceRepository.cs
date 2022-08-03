using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuAllowanceRepository : RepositoryBase<HuAllowance>, IHuAllowanceRepository
    {
        public HuAllowanceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuAllowance> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }

}
