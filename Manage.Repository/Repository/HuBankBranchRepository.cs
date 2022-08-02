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
    public class HuBankBranchRepository : RepositoryBase<HuBankBranch>, IHuBankBranchRepository
    {
        public HuBankBranchRepository(DatabaseContext context) : base(context)
        {
        }

        
    }
}
