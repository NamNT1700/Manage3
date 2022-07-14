using AutoMapper;
using Manage.Common;
using Manage.Model.DTO.Allwance;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.Models;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class AllwanceService : IAllwanceService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context ;
        private IConfiguration _configuration;

        public AllwanceService(IMapper mapper, IConfiguration configuration,
            IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _configuration = configuration;
            _repositoryWrapper = repositoryWrapper;
            _context = context;

        }
        public async Task<Response> AddNew(AllwanceDTO allwance)
        {
            Response responce = new Response();
            string message = await _repositoryWrapper.Allwance.CheckData(allwance);
            if (message != null)
            {
                responce.message = message;
                responce.status = "400";
                return responce;
            }

            HuAllwance huAllwance = _mapper.Map<HuAllwance>(allwance);
            await _repositoryWrapper.Allwance.Create(huAllwance);
            await _repositoryWrapper.SaveAsync();
            AllwanceDTO allwanceDTO = _mapper.Map<AllwanceDTO>(huAllwance);
            responce.status = "200";
            responce.item = allwanceDTO;
            return responce;
        }
    }
}
