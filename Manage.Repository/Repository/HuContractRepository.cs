﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Contract;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuContractRepository : RepositoryBase<HuContract>, IHuContractRepository
    {
        public HuContractRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<List<HuContract>> GetAll()
        {
            return await Task.Run(() => FindAll().OrderBy(a => a.Id).ToList());
        }
    }
}
