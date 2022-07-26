using AutoMapper;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.Contract;
using Manage.Model.DTO.Hospital;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Title;
using Manage.Model.DTO.User;
using Manage.Model.Models;


namespace Manage.API
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //map HuAllowance
            CreateMap<HuAllowance, AllowanceDTO>();
            CreateMap<AllowanceDTO, HuAllowance>();

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





            CreateMap<HuAllowance, ListAllowanceDTO>();
            CreateMap<HuBank, ListBankDTO>();
            CreateMap<HuContract, ListContractDTO>();
            CreateMap<HuHospital, ListHospitalDTO>();
            CreateMap<HuNation, ListNationDTO>();
            CreateMap<HuTitle, ListTitleDTO>();
           

            CreateMap<UpdateDataAllowance, HuAllowance>();
            CreateMap<UpdateBank, HuBank>();
            CreateMap<UpdateContract, HuContract>();
            CreateMap<UpdateHospital, HuHospital>();
            CreateMap<UpdateNation, HuNation>();
            CreateMap<UpdateTitle, HuTitle>();

            CreateMap<UserDTO, SeUser>();
            CreateMap<SeUser, UserDTO>();
            CreateMap<SeUser, ListUserDTO>();
        }
    }
}
