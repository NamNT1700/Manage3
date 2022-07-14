using Manage.Common;
using Manage.Model.DTO.Allwance;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using System.Threading.Tasks;

namespace Manage.Repository.IRepository
{
    public interface IHuAllwanceRepository: IRepositoryBase<HuAllwance> 
    {
        public Task<string> CheckData(AllwanceDTO allwance);

    }
}
