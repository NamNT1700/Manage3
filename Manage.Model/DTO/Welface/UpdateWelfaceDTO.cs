using System;

namespace Manage.Model.DTO.Welface
{
    public class UpdateWelfaceDTO
    {
        public int Id { get; set; }
        public UpdateWelface updateData { get; set; }
    }
    public class UpdateWelface
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public int? NumberOfMonth { get; set; }
        public double? Money { get; set; }
        public string Activeflg { get; set; }
    }
}
