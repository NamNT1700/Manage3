using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Base.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        public DatabaseContext _context;
        public IHuAllowanceRepository _allowance;
        public IHuBankRepository _bank;
        public IHuContractRepository _contract;
        public IHuHospitalRepository _hospital;
        public IHuNationRepository _nation;
        public IHuTitleRepository _title;
        public IUserRepository _user;

        public IHuAllowanceRepository Allowance
        {
            get
            {
                if (_allowance == null)
                    _allowance = new HuAllowanceRepository(_context);
                return _allowance;
            }
        }

        public IHuBankRepository Bank
        {
            get
            {
                if (_bank == null)
                    _bank = new HuBankRepository(_context);
                return _bank;
            }
        }

        public IHuContractRepository Contract
        {
            get
            {
                if (_contract == null)
                    _contract = new HuContractRepository(_context);
                return _contract;
            }
        }

        public IHuHospitalRepository Hospital
        {
            get
            {
                if (_hospital == null)
                    _hospital = new HuHospitalRepository(_context);
                return _hospital;
            }
        }

        public IHuNationRepository Nation
        {
            get
            {
                if (_nation == null)
                    _nation = new HuNationRepository(_context);
                return _nation;
            }
        }

        public IHuTitleRepository Title
        {
            get
            {
                if (_title == null)
                    _title = new HuTitleRepository(_context);
                return _title;
            }
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

        public RepositoryWrapper(DatabaseContext context)
        {
            _context = context;

        }
    }
}
