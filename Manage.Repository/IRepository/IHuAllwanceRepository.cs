using Manage.Common;
using Manage.Model.DTO.Allwance;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manage.Repository.IRepository
{
    public interface IHuAllwanceRepository: IRepositoryBase<HuAllwance> 
    {
        public Task<string> CheckData(AllwanceDTO allwance);
        public Task<HuAllwance> FindByCode(string code);
        public Task<HuAllwance> FindById(int id);
        public Task<List<HuAllwance>> GetAll();
    }
}
