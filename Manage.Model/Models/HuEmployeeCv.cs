using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_employee_cv")]
    [Index(nameof(HospitalId), Name = "IX_hu_employee_cv_hospital_id")]
    public partial class HuEmployeeCv
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Column("id_card")]
        public int? IdCard { get; set; }
        [Column("sex")]
        public bool? Sex { get; set; }
        [Column("date_of_birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Column("Place_of_birth")]
        [StringLength(255)]
        public string PlaceOfBirth { get; set; }
        [Column("ethnic")]
        [StringLength(255)]
        public string Ethnic { get; set; }
        [Column("reiligion")]
        [StringLength(255)]
        public string Reiligion { get; set; }
        [Column("temporary_address")]
        [StringLength(255)]
        public string TemporaryAddress { get; set; }
        [Column("permanent_address")]
        [StringLength(255)]
        public string PermanentAddress { get; set; }
        [Column("hospital_id")]
        public int? HospitalId { get; set; }
        [Column("bank_number")]
        public int? BankNumber { get; set; }
        [Column("health_condition")]
        public bool? HealthCondition { get; set; }
        [Column("clothes_size")]
        [StringLength(20)]
        public string ClothesSize { get; set; }
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

        [ForeignKey(nameof(HospitalId))]
        [InverseProperty(nameof(HuHospital.HuEmployeeCvs))]
        public virtual HuHospital Hospital { get; set; }
    }
}
