using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Title
{
    public class TitleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
