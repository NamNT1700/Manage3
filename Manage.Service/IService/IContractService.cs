﻿using Manage.Common;
using Manage.Model.DTO.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IContractService
    {
        Task<Response> AddNew(ContractDTO contract);
    }
}
