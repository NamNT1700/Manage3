using Manage.Repository.IRepository;

namespace Manage.Repository.Base.IRepository.IWrapper
{
    public interface IUserRepositoryWrapper
    {
        IUserRepository User { get; }
    }
}
