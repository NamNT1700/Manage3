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

        public async Task<string> CheckData(NationDTO nation)
        {
            HuNation huNation = await FindByCode(nation.Code);
            if (huNation != null)
                return "code already exist";
            huNation = await FindById(nation.Id);
            if (huNation != null)
                return "id already exist";
            return null;
        }
        public async Task<List<HuNation>> GetAll()
        {
            return await Task.Run(() => FindAll().OrderBy(a => a.Id).ToList());
        }
    }
}
