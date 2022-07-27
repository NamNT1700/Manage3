using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Service.IService;

namespace Manage.Service.Service
{
    public class EmployeeFamilyService : IEmployeeFamilyService
    {
        public Task<BaseResponse> AddNew(EmployeeFamilyDTO employeeFamilyDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAll(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Update(UpdateEmployeeFamilyDTO update)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
