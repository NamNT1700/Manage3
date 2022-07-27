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
        Task<BaseResponse> AddNew(NationDTO nation);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateNationDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
