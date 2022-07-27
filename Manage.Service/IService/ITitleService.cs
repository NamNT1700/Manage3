﻿using Manage.Common;
using Manage.Model.DTO.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface ITitleService
    {
        Task<BaseResponse> AddNew(TitleDTO title);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateTitleDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
