using Manage.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Base.IRepository
{
    public interface IRepositoryWrapper
    {
        IHuAllowanceRepository Allowance { get; }
        IHuBankRepository Bank { get; }
        IHuContractRepository Contract { get; }
        IHuHospitalRepository Hospital { get; }
        IHuNationRepository Nation { get; }
        IHuTitleRepository Title { get; }
        IUserRepository User { get; }
    }
}
