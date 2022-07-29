﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeFamily
{
    public class EmployeeFamilyDTO
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? EmployeeId { get; set; }
        public int? RelationId { get; set; }
        public int? IdNo { get; set; }
        public string IsDeduct { get; set; }
        public DateTime? DeductFrom { get; set; }
        public DateTime? DeductTo { get; set; }
        public string Remark { get; set; }

    }
}
