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
    public class HuWardRepository : RepositoryBase<HuWard>, IHuWardRepository
    {
        public HuWardRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuWard> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
