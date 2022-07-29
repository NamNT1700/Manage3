using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.EmployeeEducation;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class EmployeeEducationService : IEmployeeEducationService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeEducationService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(EmployeeEducationDTO employeeEducationDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Update(UpdateEmployeeEducationDTO update)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
