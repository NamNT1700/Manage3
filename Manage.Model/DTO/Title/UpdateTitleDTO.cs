using System;

namespace Manage.Model.DTO.Title
{
    public class UpdateTitleDTO
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
    }
}
