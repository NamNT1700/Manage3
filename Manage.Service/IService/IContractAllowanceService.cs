﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.ContractAllowance;

namespace Manage.Service.IService
{
    public interface IContractAllowanceService
    {
        Task<BaseResponse> AddNew(ContractAllowanceDTO contractAllowanceDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateContractAllowanceDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
