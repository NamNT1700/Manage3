using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;

namespace Manage.Repository.Base.Repository.Wrapper
{
    public class HuBankRepositoryWrapper : IHuBankRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private IHuBankRepository _bank;

        public HuBankRepositoryWrapper(DatabaseContext context)
        {
           
            _context = context;
        }
        public IHuBankRepository Bank {
            get
            {
                if (_bank == null)
                    _bank = new HuBankRepository(_context);
                return _bank;
            }
        }
    }
}
