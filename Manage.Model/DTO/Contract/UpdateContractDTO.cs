using System;

namespace Manage.Model.DTO.Contract
{
   public class UpdateContractDTO
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
       public string Note { get; set; }
       public int? NumberOfMonth { get; set; }
       public double? Money { get; set; }
       public bool? Activeflg { get; set; }
    }
}
