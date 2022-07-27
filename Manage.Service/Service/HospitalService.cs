﻿using System;
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

namespace Manage.Service.Service
{
    public class HospitalService : IHospitalService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public HospitalService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public async Task<BaseResponse> AddNew(HospitalDTO hospital)
        {
            BaseResponse responce = new BaseResponse();

            HuHospital huHospital = _mapper.Map<HuHospital>(hospital);
            huHospital.CreatedTime = DateTime.Now;
            huHospital.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Hospital.Create(huHospital);
            await _context.SaveChangesAsync();
            HospitalDTO hospitalDto = _mapper.Map<HospitalDTO>(huHospital);
            responce.status = "200";
            responce.item = hospitalDto;
            return responce;
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuHospital> huContracts = await _repositoryWrapper.Hospital.GetAll();
            List<ListHospitalDTO> listAllwance = _mapper.Map<List<ListHospitalDTO>>(huContracts);
            List<ListHospitalDTO> lists = new List<ListHospitalDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huContracts.Count())
            {
                response.status = "400";
                response.success = false;
                response.message = "no user yet";
                return response;
            }
            if (firstIndex + request.pageSize < huContracts.Count())
                lists = listAllwance.GetRange(firstIndex, request.pageSize);
            else lists = listAllwance.GetRange(firstIndex, listAllwance.Count - firstIndex);
            response.status = "200";
            response.success = true;
            response.item = lists;
            return response;
        }

        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuHospital hospital = await _repositoryWrapper.Hospital.FindById(id);
            if (hospital != null)
            {
                HospitalDTO contract = _mapper.Map<HospitalDTO>(hospital);
                response.item = contract;
                response.status = "200";
                response.success = true;
                return response;
            }
            response.message = $"no hospital with id {id} exist";
            response.status = "400";
            response.success = false;
            return response;
        }



        public async Task<BaseResponse> Update(UpdateHospitalDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuHospital hospital = await _repositoryWrapper.Hospital.FindById(update.Id);
            if (hospital != null)
            {
                _mapper.Map(update.updateData, hospital);
                hospital.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                response.status = "200";
                response.success = true;
                response.item = hospital;
                return response;
            }
            response.message = "update data fail";
            response.status = "400";
            response.success = false;
            return response;
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            BaseResponse response = new BaseResponse();
            foreach (int id in ids)
            {
                HuHospital hospital = await _repositoryWrapper.Hospital.FindById(id);
                await _repositoryWrapper.Hospital.Delete(hospital);
            }
            response.message = "Delete hospital";
            response.status = "200";
            response.success = true;
            return response;
        }
    }
}
