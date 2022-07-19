

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;
namespace Manage.Model.Models
{
    [Table("hu_bank_branch")]
    [Index(nameof(BankId), Name = "IX_hu_bank_branch_bank_id")]
    public partial class HuBankBranch : IEntityBase
    {
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("bank_id")]
        public int? BankId { get; set; }
        [Column("activeflg")]
        public bool? Activeflg { get; set; }
        [ForeignKey(nameof(BankId))]
        [InverseProperty(nameof(HuBank.HuBankBranches))]
        public virtual HuBank Bank { get; set; }
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
    }
}
