using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuSchoolRepository : RepositoryBase<HuSchool>, IHuSchoolRepository
    {
        public HuSchoolRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<HuSchool>> GetAll(BaseRequest baseRequest)
        {
            return await Task.Run(() => FindAll()
            .Where(n => n.Schools.Equals(baseRequest.keyworks))
            .OrderBy(a => a.Id)
            .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
            .Take(baseRequest.pageSize)
            .ToList());
        }
    }
}
