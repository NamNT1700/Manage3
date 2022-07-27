using Manage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.DTO.Welface;

namespace Manage.Service.IService
{
    public interface IWelfaceService
    {
        Task<BaseResponse> AddNew(WelfaceDTO welfaceDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateWelfaceDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> AddNew(WelfaceDTO welface);
    }
}
