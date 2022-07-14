using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Allwance;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuAllwanceRepository : RepositoryBase<HuAllwance>, IHuAllwanceRepository
    {
        public HuAllwanceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task AddNew(HuAllwance huAllwance)
        {
            await Task.Run(()=>Create(huAllwance));
        }

        public async Task<string> CheckData(AllwanceDTO allwance)
        {
            string valid = await CheckId.Check(allwance.Id);
            if (valid != null)
                return valid;
            return null;
        }
    }

}
