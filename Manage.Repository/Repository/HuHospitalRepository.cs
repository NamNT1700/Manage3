using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Hospital;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;

namespace Manage.Repository.Repository
{
    public class HuHospitalRepository : RepositoryBase<HuHospital>, IHuHospitalRepository
    {
        public HuHospitalRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<string> CheckData(HospitalDTO hospital)
        {
            HuHospital huHospital = await FindByCode(hospital.Code);
            if (huHospital != null)
                return "code already exist";
            huHospital = await FindById(hospital.Id);
            if (huHospital != null)
                return "id already exist";
            return null;
        }
        public async Task<List<HuHospital>> GetAll()
        {
            return await Task.Run(() => FindAll().OrderBy(a => a.Id).ToList());
        }
    }
}
