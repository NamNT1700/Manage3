using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Hospital;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuHospitalRepository : RepositoryBase<HuHospital>, IHuHospitalRepository
    {
        public HuHospitalRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuHospital> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<HuHospital>> GetAll(BaseRequest baseRequest)
        {
            return await Task.Run(() => FindAll()
           .Where(n => n.Name.Equals(baseRequest.keyworks) && n.Activeflg.Equals("A"))
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToList());
        }
    }
}
