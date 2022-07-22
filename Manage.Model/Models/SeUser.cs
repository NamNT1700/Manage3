using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Base;

namespace Manage.Model.Models
{
    [Table("Se_User")]
    public class SeUser : IEntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("Role")]
        [StringLength(50)]
        public string Role { get; set; }
        [Column("Created_by")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("Created_time", TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column("Last_updated_by")]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        [Column("Last_update_time", TypeName = "datetime")]
        public DateTime? LastUpdateTime { get; set; }
        [Column("Username")]
        public string username { get; set; }
        [Column("Password")]
        public string password { get; set; }
        [Column("ActiveFlg")]
        public string activeflg { get; set; }
    }
}
