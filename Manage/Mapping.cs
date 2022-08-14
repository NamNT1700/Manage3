using AutoMapper;
using Manage.Common;
using Manage.Model.DTO.Allowance;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.Contract;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Model.DTO.District;
using Manage.Model.DTO.Employee;
using Manage.Model.DTO.EmployeeCv;
using Manage.Model.DTO.EmployeeEducation;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Model.DTO.Hospital;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.DTO.OtherList;
using Manage.Model.DTO.OtherListType;
using Manage.Model.DTO.Province;
using Manage.Model.DTO.SalaryRecord;
using Manage.Model.DTO.School;
using Manage.Model.DTO.Title;
using Manage.Model.DTO.User;
using Manage.Model.DTO.Ward;
using Manage.Model.DTO.Welface;
using Manage.Model.Models;
using System;
using System.Collections.Generic;
using UpdateDataAllowance = Manage.Model.DTO.Allowance.UpdateDataAllowance;


namespace Manage.API
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<HuAllowance, AllowanceDTO>();
            CreateMap<AllowanceDTO, HuAllowance>();
            CreateMap<HuAllowance, ListAllowanceDTO>();
            CreateMap<UpdateDataAllowance, HuAllowance>();
            CreateMap<UserInfoCreate, HuAllowance>();
            CreateMap<UserInfoUpdate, HuAllowance>();

            CreateMap<BankDTO, HuBank>();
            CreateMap<HuBank, BankDTO>();
            CreateMap<HuBank, ListBankDTO>();
            CreateMap<UpdateBank, HuBank>();
            CreateMap<UserInfoCreate, HuBank>();
            CreateMap<UserInfoUpdate, HuBank>();

            CreateMap<BankBranchDTO, HuBankBranch>();
            CreateMap<HuBankBranch, BankBranchDTO>();
            CreateMap<HuBankBranch, ListBankBranch>();
            CreateMap<ListBankBranch, ListBankBranchDTO>();
            CreateMap<UpdateBankBranch, HuBankBranch>();
            CreateMap<UserInfoCreate, HuBankBranch>();
            CreateMap<UserInfoUpdate, HuBankBranch>();

            CreateMap<ContractAllowanceDTO, HuContractAllowance>();
            CreateMap<HuContractAllowance, ContractAllowanceDTO>();
            CreateMap<HuContractAllowance, ContractAllowance>();
            CreateMap<ContractAllowance, ContractAllowanceDTO>();
            CreateMap<HuContractAllowance, ListContractAllowanceDTO>();
            CreateMap<UpdateContractAllowance, HuContractAllowance>();
            CreateMap<UserInfoCreate, HuContractAllowance>();
            CreateMap<UserInfoUpdate, HuContractAllowance>();

            CreateMap<ContractDTO, HuContract>();
            CreateMap<HuContract, ContractDTO>();
            CreateMap<HuContract, ListContractDTO>();
            CreateMap<UpdateContract, HuContract>();
            CreateMap<UserInfoCreate, HuContract>();
            CreateMap<UserInfoUpdate, HuContract>();

            CreateMap<ContractualBenefitDTO, HuContractWelface>();
            CreateMap<HuContractWelface, ContractualBenefitDTO>();
            CreateMap<HuContractWelface, ListContractualBenefitDTO>();
            CreateMap<UpdateContractualBenefit, HuContractWelface>();
            CreateMap<UserInfoCreate, HuContractWelface>();
            CreateMap<UserInfoUpdate, HuContractWelface>();

            CreateMap<DistrictDTO, HuDistrict>();
            CreateMap<HuDistrict, DistrictDTO>();
            CreateMap<HuDistrict, ListDistrict>();
            CreateMap<ListDistrict, ListDistrictDTO>();
            CreateMap<UpdateDistrict, HuDistrict>();
            CreateMap<UserInfoCreate, HuDistrict>();
            CreateMap<UserInfoUpdate, HuDistrict>();



            CreateMap<EmployeeDTO, HuEmployee>();
            CreateMap<HuEmployee, EmployeeDTO>();
            CreateMap<HuEmployee, ListEmployeeDTO>();
            CreateMap<UpdateEmployee, HuEmployee>();
            CreateMap<UserInfoCreate, HuEmployee>();
            CreateMap<UserInfoUpdate, HuEmployee>();

            CreateMap<EmployeeCvDTO, HuEmployeeCv>();
            CreateMap<HuEmployeeCv, EmployeeCvDTO>();
            CreateMap<HuEmployeeCv, ListEmployeeCvDTO>();
            CreateMap<UpdateEmployeeCvDTO, HuEmployeeCv>();
            CreateMap<UserInfoCreate, HuEmployeeCv>();
            CreateMap<UserInfoUpdate, HuEmployeeCv>();

            CreateMap<EmployeeEducationDTO, HuEmployeeEducation>();
            CreateMap<HuEmployeeEducation, EmployeeEducationDTO>();
            CreateMap<HuEmployeeEducation, ListEmployeeEducationDTO>();
            CreateMap<UpdateEmployeeEducation, HuEmployeeEducation>();
            CreateMap<UserInfoCreate, HuEmployeeEducation>();
            CreateMap<UserInfoUpdate, HuEmployeeEducation>();


            CreateMap<EmployeeFamilyDTO, HuEmployeeFamily>();
            CreateMap<HuEmployeeFamily, EmployeeFamilyDTO>();
            CreateMap<HuEmployeeFamily, EmployeeFamilyDTO>();
            CreateMap<UpdateEmployeeFamily, HuEmployeeFamily>();
            CreateMap<UserInfoCreate, HuEmployeeFamily>();
            CreateMap<UserInfoUpdate, HuEmployeeFamily>();

            CreateMap<HospitalDTO, HuHospital>();
            CreateMap<HuHospital, HospitalDTO>();
            CreateMap<HuHospital, ListHospitalDTO>();
            CreateMap<UpdateHospital, HuHospital>();
            CreateMap<UserInfoCreate, HuHospital>();
            CreateMap<UserInfoUpdate, HuHospital>();


            CreateMap<OrganizationDTO, HuOrganization>();
            CreateMap<HuOrganization, OrganizationDTO>();
            CreateMap<HuOrganization, ListOrganization>();
            CreateMap<ListOrganization, ListOrganizationDTO>();
            CreateMap<UpdateOrganization, HuOrganization>();
            CreateMap<UserInfoCreate, HuOrganization>();
            CreateMap<UserInfoUpdate, HuOrganization>();

            CreateMap<OrgTitleDTO, HuOrgTitle>();
            CreateMap<HuOrgTitle, OrgTitleDTO>();
            CreateMap<HuOrgTitle, ListOrgTitle>();
            CreateMap<ListOrgTitle, ListOrgTitleDTO>();
            CreateMap<UpdateOrgTitle, HuOrgTitle>();
            CreateMap<UserInfoCreate, HuOrgTitle>();
            CreateMap<UserInfoUpdate, HuOrgTitle>();

            CreateMap<OtherListDTO, OtherList>();
            CreateMap<OtherList, OtherListDTO>();
            CreateMap<OtherList, ListOtherListDTO>();
            CreateMap<UpdateOtherList, OtherList>();
            CreateMap<UserInfoCreate, OtherList>();
            CreateMap<UserInfoUpdate, OtherList>();

            CreateMap<OtherListTypeDTO, OtherListType>();
            CreateMap<OtherListType, OtherListTypeDTO>();
            CreateMap<OtherListType, ListOtherListTypeDTO>();
            CreateMap<UpdateOtherListType, OtherListType>();
            CreateMap<UserInfoCreate, OtherListType>();
            CreateMap<UserInfoUpdate, OtherListType>();

            CreateMap<ProvinceDTO, HuProvince>();
            CreateMap<HuProvince, ProvinceDTO>();
            CreateMap<UpdateProvince, HuProvince>();
            CreateMap<HuProvince, ListProvince>();
            CreateMap<ListProvince, ListProvinceDTO>();
            CreateMap<UserInfoCreate, HuProvince>();
            CreateMap<UserInfoUpdate, HuProvince>();

            CreateMap<SalaryRecordDTO, HuSalaryRecord>();
            CreateMap<HuSalaryRecord, SalaryRecordDTO>();
            CreateMap<UpdateSalaryRecord, HuSalaryRecord>();
            CreateMap<HuSalaryRecord, ListSalaryRecordDTO>();
            CreateMap<UserInfoCreate, HuSalaryRecord>();
            CreateMap<UserInfoUpdate, HuSalaryRecord>();

            CreateMap<SchoolDTO, HuSchool>();
            CreateMap<HuSchool, SchoolDTO>();
            CreateMap<UpdateSchool, HuSchool>();
            CreateMap<HuSchool, ListSchoolDTO>();
            CreateMap<UserInfoCreate, HuSchool>();
            CreateMap<UserInfoUpdate, HuSchool>();

            CreateMap<NationDTO, HuNation>();
            CreateMap<HuNation, NationDTO>();
            CreateMap<UpdateNation, HuNation>();
            CreateMap<HuNation, ListNationDTO>();
            CreateMap<UserInfoCreate, HuNation>();
            CreateMap<UserInfoUpdate, HuNation>();

            CreateMap<TitleDTO, HuTitle>();
            CreateMap<HuTitle, TitleDTO>();
            CreateMap<UpdateTitle, HuTitle>();
            CreateMap<HuTitle, ListTitleDTO>();
            CreateMap<UserInfoCreate, HuTitle>();
            CreateMap<UserInfoUpdate, HuTitle>();  

            CreateMap<UserDTO, SeUser>();
            CreateMap<SeUser, UserDTO>();
            CreateMap<UpdateUserDTO, SeUser>();
            CreateMap<SeUser, ListUserDTO>();
            CreateMap<UserInfoCreate, SeUser>();
            CreateMap<UserInfoUpdate, SeUser>();

            CreateMap<WardDTO, HuWard>();
            CreateMap<HuWard, WardDTO>();
            CreateMap<HuWard, ListWard>();
            CreateMap<ListWard, ListWardDTO>();
            CreateMap<UpdateWard, HuWard>(); 
            CreateMap<UserInfoCreate, HuWard>();
            CreateMap<UserInfoUpdate, HuWard>();

            CreateMap<WelfaceDTO, HuWelface>();
            CreateMap<HuWelface, WelfaceDTO>();
            CreateMap<HuWelface, ListWelfaceDTO> ();
            CreateMap<UpdateWelface, HuWelface>();
            CreateMap<UserInfoCreate, HuWelface>();
            CreateMap<UserInfoUpdate, HuWelface>();
        }
    }
}
