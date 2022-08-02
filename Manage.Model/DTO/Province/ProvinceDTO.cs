﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Province
{
    public class ProvinceDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? NationId { get; set; }

    }
}
