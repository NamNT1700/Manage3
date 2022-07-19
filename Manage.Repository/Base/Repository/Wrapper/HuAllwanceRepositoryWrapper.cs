using Manage.Model.Context;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;

namespace Manage.Repository.Base.Repository.Wrapper
{
    public class HuAllwanceRepositoryWrapper : IHuAllwanceRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private IHuAllwanceRepository _allwance;
        public HuAllwanceRepositoryWrapper(DatabaseContext context)
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
    }
}
