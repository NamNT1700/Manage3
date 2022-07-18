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
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuAllwanceRepository : RepositoryBase<HuAllwance>, IHuAllwanceRepository
    {
        public HuAllwanceRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<string> CheckData(AllwanceDTO allwance)
        {
            HuAllwance huAllwance = await FindByCode(allwance.Code);
            if (huAllwance != null)
                return "code already exist";
            huAllwance = await FindById(allwance.Id);
            if (huAllwance != null)
                return "id already exist";
            return null;
        }

        public async Task<HuAllwance> FindByCode(string code)
        {
            return await FindByCondition(a => a.Code.Equals(code)).FirstOrDefaultAsync();
        }

        public async Task<HuAllwance> FindById(int id)
        {
            return await FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();

        }

        public async Task<List<HuAllwance>> GetAll()
        {
            return await Task.Run(()=> FindAll().OrderBy(a => a.Id).ToList());
        }
    }

}
