using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OtherList;

namespace Manage.Service.IService
{
    public interface IOtherListService
    {
        Task<BaseResponse> AddNew(OtherListDTO otherListDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOtherListDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
