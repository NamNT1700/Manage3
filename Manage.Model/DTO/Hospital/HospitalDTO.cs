using System;

namespace Manage.Model.DTO.Hospital
{
    public class HospitalDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool? Activeflg { get; set; }
    }
}
