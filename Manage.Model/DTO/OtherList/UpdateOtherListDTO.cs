﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OtherList
{
    public class UpdateOtherListDTO
    {
        public int id { get; set; }
        public UpdateOtherList updateData { get; set; }
    }
    public class UpdateOtherList
    {
        public int? TypeId { get; set; }
        public string Activeflg { get; set; }
    }
}
