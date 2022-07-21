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
    [Table("hu_welface")]
    public partial class HuWelface : IEntityBase
    {
        public HuWelface()
        {
            HuContractualBenefits = new HashSet<HuContractualBenefit>();
            HuSalaryRecords = new HashSet<HuSalaryRecord>();
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
        [StringLength(255)]
        public string Name { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }
        [InverseProperty(nameof(HuContractualBenefit.Welface))]
        public virtual ICollection<HuContractualBenefit> HuContractualBenefits { get; set; }
        [InverseProperty(nameof(HuSalaryRecord.ContractWelface))]
        public virtual ICollection<HuSalaryRecord> HuSalaryRecords { get; set; }
    }
}
