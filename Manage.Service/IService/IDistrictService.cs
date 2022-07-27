using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.District;

namespace Manage.Service.IService
{
    public interface IDistrictService
    {
        Task<BaseResponse> AddNew(DistrictDTO districtDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateDistrictDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
