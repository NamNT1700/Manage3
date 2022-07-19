using System;

namespace Manage.Model.DTO.Hospital
{
    public class UpdateHospitalDTO
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
        public string Address { get; set; }
        public bool? Activeflg { get; set; }
    }
}
