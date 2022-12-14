using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.SalaryRecord;

namespace Manage.Service.IService
{
    public interface ISalaryRecordService
    {
        Task<BaseResponse> AddNew(SalaryRecordDTO salaryRecordDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateSalaryRecordDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
