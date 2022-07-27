using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Employee;

namespace Manage.Service.IService
{
    public interface IEmployeeService
    {
        Task<BaseResponse> AddNew(EmployeeDTO employeeDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateEmployeeDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
