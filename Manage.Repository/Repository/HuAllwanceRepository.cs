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
        public async Task<List<HuAllwance>> GetAll()
        {
            return await Task.Run(()=> FindAll().OrderBy(a => a.Id).ToList());
        }
    }

}
