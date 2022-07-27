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

namespace Manage.Service.Service
{
    public class NationService : INationService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;


        public NationService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
        }

        public async Task<BaseResponse> AddNew(NationDTO nation)
        {
            BaseResponse responce = new BaseResponse();

            HuNation huNation = _mapper.Map<HuNation>(nation);
            huNation.CreatedTime = DateTime.Now;
            huNation.LastUpdateTime = DateTime.Now;
            await _repositoryWrapper.Nation.Create(huNation);
            huNation.Code = CreateCode.AllowanceCode(huNation.Id);
            await _context.SaveChangesAsync();
            NationDTO hospitalDto = _mapper.Map<NationDTO>(huNation);
            return Response.SuccessResponse();
        }



        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            List<HuNation> huNations = await _repositoryWrapper.Nation.GetAll(request);
            List<ListNationDTO> listAllwance = _mapper.Map<List<ListNationDTO>>(huNations);
            List<ListNationDTO> lists = new List<ListNationDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huNations.Count())
                response = Response.DuplicateDataResponse("no user yet");
            if (firstIndex + request.pageSize < huNations.Count())
                lists = listAllwance.GetRange(firstIndex, request.pageSize);
            else lists = listAllwance.GetRange(firstIndex, listAllwance.Count - firstIndex);
            return Response.SuccessResponse(lists);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            HuNation nation = await _repositoryWrapper.Nation.FindById(id);
            if (nation != null)
            {
                HospitalDTO contract = _mapper.Map<HospitalDTO>(nation);
                return Response.SuccessResponse(response);
            }
            return Response.NotFoundResponse();
        }



        public async Task<BaseResponse> Update(UpdateNationDTO update)
        {
            BaseResponse response = new BaseResponse();
            HuNation nation = await _repositoryWrapper.Nation.FindById(update.Id);
            if (nation != null)
            {
                _mapper.Map(update.updateData, nation);
                nation.LastUpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Response.SuccessResponse(response);
            }
            return Response.DataNullResponse();
        }
        public async Task<BaseResponse> Delete(List<int> ids)
        {
            BaseResponse response = new BaseResponse();
            foreach (int id in ids)
            {
                HuNation hospital = await _repositoryWrapper.Nation.FindById(id);
                await _repositoryWrapper.Nation.Delete(hospital);
            }
            return Response.SuccessResponse();
        }
    }
}
