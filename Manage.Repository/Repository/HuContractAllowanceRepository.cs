﻿using System;
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
    public class HuContractAllowanceRepository : RepositoryBase<HuContractAllowance>, IHuContractAllowanceRepository
    {
        public HuContractAllowanceRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<HuContractAllowance> FindById(int? id)
        {
            return await FindByCondition(n => n.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
