using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.School;

namespace Manage.Service.IService
{
    public interface ISchoolService
    {
        Task<BaseResponse> AddNew(SchoolDTO schoolDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateSchoolDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
