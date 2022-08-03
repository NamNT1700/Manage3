﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuWelfaceRepository : IRepositoryBase<HuWelface>
    {
        Task<HuWelface> FindByName(string name);
    }
}
