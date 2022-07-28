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
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;


        public NationService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
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
            var huNations = await _repositoryWrapper.Nation.GetAll(request);
            var listNations = _mapper.Map<List<ListNationDTO>>(huNations);
            var lists = new List<ListNationDTO>();
            var firstIndex = (request.pageNum - 1) * request.pageSize;
            BaseResponse response = new BaseResponse();
            List<HuNation> huNations = await _repositoryWrapper.Nation.GetAll(request);
            List<HuNation> huNations = await _repositoryWrapper.Nation.GetAll();
            List<ListNationDTO> listAllwance = _mapper.Map<List<ListNationDTO>>(huNations);
            List<ListNationDTO> lists = new List<ListNationDTO>();
            int firstIndex = (request.pageNum - 1) * request.pageSize;
            if (firstIndex >= huNations.Count())
                Response.DuplicateDataResponse("no user yet");
            else if (firstIndex + request.pageSize < huNations.Count())
                lists = listNations.GetRange(firstIndex, request.pageSize);
            else lists = listNations.GetRange(firstIndex, listNations.Count - firstIndex);
            return Response.SuccessResponse(lists);
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
