using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.District
{
   public class UpdateDistrictDTO
    {
        public int Id { get; set; }
        public UpdateData updateData { get; set; }
    }
   public class UpdateData
   {
       public string CreatedBy { get; set; }
       public DateTime? CreatedTime { get; set; }
       public string LastUpdatedBy { get; set; }
       public DateTime? LastUpdateTime { get; set; }
       public string Name { get; set; }
       public int? ProvinceId { get; set; }
       public bool? Activeflg { get; set; }
    }
}
