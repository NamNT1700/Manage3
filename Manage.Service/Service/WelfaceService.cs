using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Welface;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.Service
{
    public class WelfaceService: IWelfaceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public WelfaceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public Task<Response> AddNew(WelfaceDTO welface)
        {
            throw new NotImplementedException();
        }
    }
}
