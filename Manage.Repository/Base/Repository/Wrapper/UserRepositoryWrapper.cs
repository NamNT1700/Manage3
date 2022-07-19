using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;

namespace Manage.Repository.Base.Repository.Wrapper
{
    public class UserRepositoryWrapper : IUserRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private IUserRepository _user;

        public UserRepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context);
                return _user;
            }
        }
    }
}
