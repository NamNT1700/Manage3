﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.EmployeeEducation;

namespace Manage.Service.IService
{
    public interface IEmployeeEducationService
    {
        Task<BaseResponse> AddNew(EmployeeEducationDTO employeeEducationDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateEmployeeEducationDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
