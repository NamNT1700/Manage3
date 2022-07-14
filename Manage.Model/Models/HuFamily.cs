using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_family")]
    [Index(nameof(EmployeeId), Name = "IX_hu_family_employee_id")]
    public partial class HuFamily
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("first_name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("full_name")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column("relationship")]
        [StringLength(20)]
        public string Relationship { get; set; }
        [Column("nation")]
        [StringLength(20)]
        public string Nation { get; set; }
        [Column("province")]
        [StringLength(20)]
        public string Province { get; set; }
        [Column("district")]
        [StringLength(50)]
        public string District { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("phonenumber")]
        [StringLength(15)]
        public string Phonenumber { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
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

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuFamilies))]
        public virtual HuEmployee Employee { get; set; }
    }
}
