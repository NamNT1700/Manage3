﻿using Manage.Common;
using Manage.Model.DTO.Weface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IWelfaceService
    {
        Task<Response> AddNew(WelfaceDTO welface);
    }
}
