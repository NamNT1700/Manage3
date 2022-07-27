using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.EmployeeFamily;

namespace Manage.Service.IService
{
    public interface IEmployeeFamilyService
    {
        Task<BaseResponse> AddNew(EmployeeFamilyDTO employeeFamilyDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateEmployeeFamilyDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
