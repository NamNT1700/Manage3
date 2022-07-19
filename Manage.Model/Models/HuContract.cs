﻿

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;
namespace Manage.Model.Models
{
    [Table("hu_contract")]
    public partial class HuContract : IEntityBase
    {
        public HuContract()
        {
            HuContractAllowances = new HashSet<HuContractAllowance>();
            HuContractualBenefits = new HashSet<HuContractualBenefit>();
            HuEmployees = new HashSet<HuEmployee>();
            HuSalaryRecords = new HashSet<HuSalaryRecord>();
            HuTypeOfContracts = new HashSet<HuTypeOfContract>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("created_by")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("created_time", TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column("last_updated_by")]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        [Column("last_update_time", TypeName = "datetime")]
        public DateTime? LastUpdateTime { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("note")]
        [StringLength(255)]
        public string Note { get; set; }
        [Column("number_of_month")]
        public int? NumberOfMonth { get; set; }
        [Column("money")]
        public double? Money { get; set; }
        [Column("activeflg")]
        public bool? Activeflg { get; set; }
        [InverseProperty(nameof(HuContractAllowance.Contract))]
        public virtual ICollection<HuContractAllowance> HuContractAllowances { get; set; }
        [InverseProperty(nameof(HuContractualBenefit.Contract))]
        public virtual ICollection<HuContractualBenefit> HuContractualBenefits { get; set; }
        [InverseProperty(nameof(HuEmployee.Contract))]
        public virtual ICollection<HuEmployee> HuEmployees { get; set; }
        [InverseProperty(nameof(HuSalaryRecord.Contrac))]
        public virtual ICollection<HuSalaryRecord> HuSalaryRecords { get; set; }
        [InverseProperty(nameof(HuTypeOfContract.Contract))]
        public virtual ICollection<HuTypeOfContract> HuTypeOfContracts { get; set; }
    }
}
