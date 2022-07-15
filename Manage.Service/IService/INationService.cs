﻿using Manage.Common;
using Manage.Model.DTO.Nation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface INationService
    {
        Task<Response> AddNew(NationDTO nation);
    }
}
