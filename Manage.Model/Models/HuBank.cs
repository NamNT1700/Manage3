

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;
namespace Manage.Model.Models
{
    [Table("hu_bank")]
    public partial class HuBank : IEntityBase
    {
        public HuBank()
        {
            HuBankBranches = new HashSet<HuBankBranch>();
        }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }
        [InverseProperty(nameof(HuBankBranch.Bank))]
        public virtual ICollection<HuBankBranch> HuBankBranches { get; set; }
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
