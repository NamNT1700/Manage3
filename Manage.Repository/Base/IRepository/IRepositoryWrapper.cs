using Manage.Repository.IRepository;
using System.Threading.Tasks;

namespace Manage.Repository.Base.IRepository
{
    public interface IRepositoryWrapper
    {
        IHuAllwanceRepository Allwance { get; }
        IUserRepository User { get; }
        void Save();
        Task SaveAsync();
    }
}
