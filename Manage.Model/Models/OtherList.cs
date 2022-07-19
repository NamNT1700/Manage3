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
    [Table("other_list")]
    [Index(nameof(TypeId), Name = "IX_other_list_type_id")]
    public partial class OtherList : IEntityBase
    {
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
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("activeflg")]
        public bool? Activeflg { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(OtherListType.OtherList))]
        public virtual OtherListType IdNavigation { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(HuTitle.OtherLists))]
        public virtual HuTitle Type { get; set; }
    }
}
