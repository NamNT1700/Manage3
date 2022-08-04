﻿using System;
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
   public class HuWelfaceRepository : RepositoryBase<HuWelface>, IHuWelfaceRepository
    {
        public HuWelfaceRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<HuWelface> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<HuWelface>> GetAll(BaseRequest baseRequest)
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
