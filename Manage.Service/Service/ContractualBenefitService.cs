using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractualBenefitService : IContractualBenefitService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContractualBenefitService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ContractualBenefitDTO contractualBenefitDto)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Update(UpdateContractualBenefitDTO update)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
