using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Hospital;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuHospitalRepository : IRepositoryBase<HuHospital>
    {
        public Task<HuHospital> FindByCode(string code);
        public Task<HuHospital> FindById(int id);
        public Task<List<HuHospital>> GetAll();
    }
}
