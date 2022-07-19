﻿using System;

namespace Manage.Model.DTO.District
{
    public class DistrictDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public bool? Activeflg { get; set; }
    }
}