using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.District;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuProvinceRepository : RepositoryBase<HuProvince>, IHuProvinceRepository
    {
        public HuProvinceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListDistrict>> FindAllProvinceById(List<ListDistrict> listDistricts)
        {
            foreach (ListDistrict listDistrict in listDistricts)
            {
                HuProvince huProvince = await FindById(listDistrict.ProvinceId);
                listDistrict.ProvinceName = huProvince.Name;
            }
            return listDistricts;
        }

        public async Task<HuProvince> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
