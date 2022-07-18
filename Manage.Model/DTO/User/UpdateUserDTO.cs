using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.User
{
    public class UpdateUserDTO
    {   
        public int id { get; set; }  
        public string username { get; set; }
        public string password { get; set; }
        public string? token { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
