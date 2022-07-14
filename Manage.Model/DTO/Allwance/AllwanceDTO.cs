using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Allwance
{
    public class AllwanceDTO
    {
      
        public int Id { get; set; }
    
        public string Code { get; set; }
    
        public string Name { get; set; }
     
        public bool? Activeflg { get; set; }
      
        public string CreatedBy { get; set; }
   
        public DateTime? CreatedTime { get; set; }
  
        public string LastUpdatedBy { get; set; }
     
        public DateTime? LastUpdateTime { get; set; }

    
    }
}
