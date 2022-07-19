using Microsoft.EntityFrameworkCore;
using Manage.Model.Models;

#nullable disable

namespace Manage.Model.Context
{
    public partial class DatabaseContext : DbContext
    {
        

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<SeUser> SeUsers { get; set; }
        public virtual DbSet<HuAllwance> HuAllwances { get; set; }
        public virtual DbSet<HuBank> HuBanks { get; set; }
        public virtual DbSet<HuBankBranch> HuBankBranches { get; set; }
        public virtual DbSet<HuContract> HuContracts { get; set; }
        public virtual DbSet<HuContractAllowance> HuContractAllowances { get; set; }
        public virtual DbSet<HuContractualBenefit> HuContractualBenefits { get; set; }
        public virtual DbSet<HuDistrict> HuDistricts { get; set; }
        public virtual DbSet<HuEmployee> HuEmployees { get; set; }
        public virtual DbSet<HuEmployeeCv> HuEmployeeCvs { get; set; }
        public virtual DbSet<HuEmployeeEducation> HuEmployeeEducations { get; set; }
        public virtual DbSet<HuFamily> HuFamilies { get; set; }
        public virtual DbSet<HuHospital> HuHospitals { get; set; }
        public virtual DbSet<HuNation> HuNations { get; set; }
        public virtual DbSet<HuOrgTitle> HuOrgTitles { get; set; }
        public virtual DbSet<HuOrganization> HuOrganizations { get; set; }
        public virtual DbSet<HuProvince> HuProvinces { get; set; }
        public virtual DbSet<HuSalaryRecord> HuSalaryRecords { get; set; }
        public virtual DbSet<HuTitle> HuTitles { get; set; }
        public virtual DbSet<HuTypeOfContract> HuTypeOfContracts { get; set; }
        public virtual DbSet<HuWard> HuWards { get; set; }
        public virtual DbSet<HuWelface> HuWelfaces { get; set; }
        public virtual DbSet<OtherList> OtherLists { get; set; }
        public virtual DbSet<OtherListType> OtherListTypes { get; set; }

    }
}
