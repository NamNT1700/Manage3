using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NMAHJOG\\SQLEXPRESS01;Initial Catalog=Employee_manager_VMO;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<SeUser>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.username).IsUnicode(false);
                entity.Property(e => e.password).IsUnicode(false);

                entity.Property(e => e.token).IsUnicode(false);
            });
            modelBuilder.Entity<HuAllwance>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuBank>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuBankBranch>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.HuBankBranches)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_hu_bank_branch_hu_bank");
            });

            modelBuilder.Entity<HuContract>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuContractAllowance>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Allwance)
                    .WithMany(p => p.HuContractAllowances)
                    .HasForeignKey(d => d.AllwanceId)
                    .HasConstraintName("FK_hu_Contract_allowance_hu_allwance");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HuContractAllowances)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_hu_Contract_allowance_hu_contract");
            });

            modelBuilder.Entity<HuContractualBenefit>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HuContractualBenefits)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_hu_contractual_benefits_hu_contract");

                entity.HasOne(d => d.Welface)
                    .WithMany(p => p.HuContractualBenefits)
                    .HasForeignKey(d => d.WelfaceId)
                    .HasConstraintName("FK_hu_contractual_benefits_hu_welface");
            });

            modelBuilder.Entity<HuDistrict>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.HuDistricts)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_hu_district_hu_province");
            });

            modelBuilder.Entity<HuEmployee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.EmployeeCode).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HuEmployees)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_hu_employee_hu_contract");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.HuEmployees)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_hu_employee_hu_org_title");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.HuEmployees)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_hu_employee_hu_title");
            });

            modelBuilder.Entity<HuEmployeeCv>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClothesSize).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.HuEmployeeCvs)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_hu_employee_cv_hu_hospital");
            });

            modelBuilder.Entity<HuEmployeeEducation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HuEmployeeEducations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_hu_employee_education_hu_employee");
            });

            modelBuilder.Entity<HuFamily>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HuFamilies)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_hu_family_hu_employee");
            });

            modelBuilder.Entity<HuHospital>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuNation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuOrgTitle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuOrganization>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuProvince>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.HuProvinces)
                    .HasForeignKey(d => d.NationId)
                    .HasConstraintName("FK_hu_province_hu_nation");
            });

            modelBuilder.Entity<HuSalaryRecord>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Contrac)
                    .WithMany(p => p.HuSalaryRecords)
                    .HasForeignKey(d => d.ContracId)
                    .HasConstraintName("FK_hu_salary_records_hu_contract");

                entity.HasOne(d => d.ContractAllwance)
                    .WithMany(p => p.HuSalaryRecords)
                    .HasForeignKey(d => d.ContractAllwanceId)
                    .HasConstraintName("FK_hu_salary_records_hu_Contract_allowance");

                entity.HasOne(d => d.ContractWelface)
                    .WithMany(p => p.HuSalaryRecords)
                    .HasForeignKey(d => d.ContractWelfaceId)
                    .HasConstraintName("FK_hu_salary_records_hu_welface");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HuSalaryRecords)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_hu_salary_records_hu_employee");
            });

            modelBuilder.Entity<HuTitle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<HuTypeOfContract>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HuTypeOfContracts)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_hu_type_of_contract_hu_contract");
            });

            modelBuilder.Entity<HuWard>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Distric)
                    .WithMany(p => p.HuWards)
                    .HasForeignKey(d => d.DistricId)
                    .HasConstraintName("FK_hu_ward_hu_district");
            });

            modelBuilder.Entity<HuWelface>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<OtherList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.OtherList)
                    .HasForeignKey<OtherList>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_OtherList");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.OtherLists)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_other_list_hu_title");
            });

            modelBuilder.Entity<OtherListType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
