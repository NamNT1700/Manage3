using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OtherListType;

namespace Manage.Service.IService
{
    public interface IOtherListTypeService
    {
        Task<BaseResponse> AddNew(OtherListTypeDTO otherListTypeDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOtherListTypeDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
