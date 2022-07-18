using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.Models
{
    [Table("Se_User")]
    public class SeUser
    {
        [Column("Id")]
        [Key]
        public int id { get; set; }
        [Column("Username")]
        public string username { get; set; }
        [Column("Password")]
        public string password { get; set; }
        [Column("Token")]
        public string? token { get; set; }
        [Column("ActiveFlg")]
        public string activeflg { get; set; }
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
