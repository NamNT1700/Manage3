using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuEmployeeRepository : RepositoryBase<HuEmployee>, IHuEmployeeRepository
    {
        public HuEmployeeRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<HuEmployee> FindByName(string name)
        {
            return await FindByCondition(n => n.FullName.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<HuEmployee> FindById(int? id)
        {
            return await FindByCondition(n => n.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
