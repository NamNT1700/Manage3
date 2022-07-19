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
    public class HuHospitalRepositoryWrapper : IHuHospitalRepositoryWrapper
    {
        private  IHuHospitalRepository _hospital;
        private readonly DatabaseContext _context;

        public HuHospitalRepositoryWrapper(DatabaseContext context)
        {
            _context = context;
            
        }
        public IHuHospitalRepository Hospital {
            get
            {
                if (_hospital == null)
                    _hospital = new HuHospitalRepository(_context);
                return _hospital;
            }
        }
    }
}
