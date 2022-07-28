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
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;


        public WelfaceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public Task<BaseResponse> AddNew(WelfaceDTO welfaceDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAll(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Update(UpdateWelfaceDTO update)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Delete(List<int> ids)
        public Task<BaseResponse> AddNew(WelfaceDTO welface)
        {
            throw new NotImplementedException();
        }
    }
}
