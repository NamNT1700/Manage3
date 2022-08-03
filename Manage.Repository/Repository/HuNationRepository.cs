using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Province;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuNationRepository : RepositoryBase<HuNation>, IHuNationRepository
    {
        public HuNationRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListProvince>> FindAllNationById(List<ListProvince> listProvinces)
        {
            foreach (ListProvince listProvince in listProvinces)
            {
                HuNation huNation = await FindById(listProvince.NationId);
                listProvince.Nation = huNation.Name;
            }
            return listProvinces;
        }

        public async  Task<HuNation> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
