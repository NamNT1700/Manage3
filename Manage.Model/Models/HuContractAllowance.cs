using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_Contract_allowance")]
    [Index(nameof(AllwanceId), Name = "IX_hu_Contract_allowance_allwance_id")]
    [Index(nameof(ContractId), Name = "IX_hu_Contract_allowance_contract_id")]
    public partial class HuContractAllowance
    {
        public HuContractAllowance()
        {
            HuSalaryRecords = new HashSet<HuSalaryRecord>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("contract_id")]
        public int? ContractId { get; set; }
        [Column("allwance_id")]
        public int? AllwanceId { get; set; }
        [Column("money")]
        public double? Money { get; set; }
        [Column("activeflg")]
        public bool? Activeflg { get; set; }
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

        [ForeignKey(nameof(AllwanceId))]
        [InverseProperty(nameof(HuAllwance.HuContractAllowances))]
        public virtual HuAllwance Allwance { get; set; }
        [ForeignKey(nameof(ContractId))]
        [InverseProperty(nameof(HuContract.HuContractAllowances))]
        public virtual HuContract Contract { get; set; }
        [InverseProperty(nameof(HuSalaryRecord.ContractAllwance))]
        public virtual ICollection<HuSalaryRecord> HuSalaryRecords { get; set; }
    }
}
