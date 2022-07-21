using System;

namespace Manage.Model.DTO.Welface
{
    public class WelfaceDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int? NumberOfMonth { get; set; }
        public double? Money { get; set; }
        public string Name { get; set; }
       
    }
}
