using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Welface
{
    public class WelfaceDTO
    {

        [Required]
        public string Note { get; set; }
        [Required]
        public int? NumberOfMonth { get; set; }
        [Required]
        public double? Money { get; set; }
        [Required]
        public string Name { get; set; }
       
    }
}
