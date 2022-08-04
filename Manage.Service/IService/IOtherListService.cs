using Manage.Common;
using Manage.Model.DTO.OtherList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    interface IOtherListService
    {
        Task<BaseResponse> AddNew(OtherListDTO otherListDTO);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOtherListDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
