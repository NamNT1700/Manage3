using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Nation;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuNationRepository : RepositoryBase<HuNation>, IHuNationRepository
    {
        public HuNationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
