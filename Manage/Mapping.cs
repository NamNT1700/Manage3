using AutoMapper;
using Manage.Model.DTO.Allwance;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.Contract;
using Manage.Model.DTO.Hospital;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Title;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using UpdateData = Manage.Model.DTO.Allwance.UpdateData;

namespace Manage.API
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //map HuAllwance
            CreateMap<HuAllwance, AllwanceDTO>();
            CreateMap<AllwanceDTO, HuAllwance>();

            CreateMap<BankDTO, HuBank>();
            CreateMap<HuBank, BankDTO>();

            CreateMap<ContractDTO, HuContract>();
            CreateMap<HuContract, ContractDTO>();

            CreateMap<HospitalDTO, HuHospital>();
            CreateMap<HuHospital, HospitalDTO>();


            CreateMap<NationDTO, HuNation>();
            CreateMap<HuNation, NationDTO>();


            CreateMap<TitleDTO, HuTitle>();
            CreateMap<HuTitle, TitleDTO>();





            CreateMap<HuAllwance, ListAllwanceDTO>();
            CreateMap<HuBank, ListBankDTO>();
            CreateMap<HuContract, ListContractDTO>();
            CreateMap<HuHospital, ListHospitalDTO>();
            CreateMap<HuNation, ListNationDTO>();
            CreateMap<HuTitle, ListTitleDTO>();
           

            CreateMap<UpdateData, HuAllwance>();
            CreateMap<UpdateData, HuBank>();
            CreateMap<UpdateData, HuContract>();
            CreateMap<UpdateData, HuHospital>();
            CreateMap<UpdateData, HuNation>();
            CreateMap<UpdateData, HuTitle>();

            CreateMap<UserDTO, SeUser>();
            CreateMap<SeUser, UserDTO>();
        }
    }
}
