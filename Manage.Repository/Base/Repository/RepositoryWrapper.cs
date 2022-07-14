using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;

namespace Manage.Repository.Base.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private  IHuAllwanceRepository _allwance;

        public RepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }

        public IHuAllwanceRepository Allwance
        {
            get
            {
                if (_allwance == null)
                    _allwance = new HuAllwanceRepository(_context);
                return _allwance;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
