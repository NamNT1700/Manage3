using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Hospital;
using Manage.Model.DTO.Nation;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class NationService : INationService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NationService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(NationDTO nation)
        {
            var huNation = _mapper.Map<HuNation>(nation);
            huNation.CreatedTime = DateTime.Now;
            huNation.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Nation.Create(huNation);
            huNation.Code = CreateCode.AllowanceCode(huNation.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<NationDTO>(huNation);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            List<HuNation> huNations = await _repositoryWrapper.Nation.GetAll(request);
            List<ListNationDTO> listAllwance = _mapper.Map<List<ListNationDTO>>(huNations);
            return Response.SuccessResponse(listAllwance);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var response = new BaseResponse();
            var nation = await _repositoryWrapper.Nation.FindById(id);
            if (nation == null) return Response.NotFoundResponse();
            _mapper.Map<HospitalDTO>(nation);
            return Response.SuccessResponse(response);
        }



        public async Task<BaseResponse> Update(UpdateNationDTO update)
        {
            var response = new BaseResponse();
            var nation = await _repositoryWrapper.Nation.FindById(update.Id);
            if (nation == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, nation);
            nation.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(response);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var nation = await _repositoryWrapper.Nation.FindById(id);
                if (nation == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var nation = await _repositoryWrapper.Nation.FindById(id);
                if (nation != null)
                    await _repositoryWrapper.Nation.Delete(nation);
            }
            return Response.SuccessResponse();

        }
    }
}
