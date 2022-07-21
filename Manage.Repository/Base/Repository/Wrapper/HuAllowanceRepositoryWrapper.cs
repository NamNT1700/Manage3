using Manage.Model.Context;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;

namespace Manage.Repository.Base.Repository.Wrapper
{
    public class HuAllowanceRepositoryWrapper : IHuAllowanceRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private IHuAllowanceRepository _allowance;
        public HuAllowanceRepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }
        public IHuAllowanceRepository Allowance
        {
            get
            {
                if (_allowance == null)
                    _allowance = new HuAllowanceRepository(_context);
                return _allowance;
            }
        }
    }
}
