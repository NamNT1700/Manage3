using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Hospital;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class HospitalService : IHospitalService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HospitalService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(HospitalDTO hospital)
        {
            if (hospital.Name == null) return Response.DataNullResponse();
            var huHospital = _mapper.Map<HuHospital>(hospital);
            huHospital.CreatedTime = DateTime.Now;
            huHospital.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Hospital.Create(huHospital);
            huHospital.Code = CreateCode.AllowanceCode(huHospital.Id);
            await _context.SaveChangesAsync();
            _mapper.Map<HospitalDTO>(huHospital);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            List<HuHospital> huContracts = await _repositoryWrapper.Hospital.GetAll(request);
            List<ListHospitalDTO> listAllwance = _mapper.Map<List<ListHospitalDTO>>(huContracts);
            return Response.SuccessResponse(listAllwance);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var response = new BaseResponse();
            var hospital = await _repositoryWrapper.Hospital.FindById(id);
            if (hospital == null) return Response.NotFoundResponse();
            _mapper.Map<HospitalDTO>(hospital);
            return Response.SuccessResponse(response);
        }



        public async Task<BaseResponse> Update(UpdateHospitalDTO update)
        {
            var response = new BaseResponse();
            var hospital = await _repositoryWrapper.Hospital.FindById(update.Id);
            if (hospital == null) return Response.DataNullResponse();
            _mapper.Map(update.updateData, hospital);
            hospital.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Response.SuccessResponse(response);
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var hospital = await _repositoryWrapper.Hospital.FindById(id);
                if (hospital == null)
                {
                    return Response.NotFoundResponse();
                }

            }
            foreach (var id in ids)
            {
                var hospital = await _repositoryWrapper.Hospital.FindById(id);
                if (hospital != null)
                    await _repositoryWrapper.Hospital.Delete(hospital);
            }
            return Response.SuccessResponse();

        }
    }
}
