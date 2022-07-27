using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.Ward;

namespace Manage.Service.IService
{
    public interface IWardService
    {
        Task<BaseResponse> AddNew(WardDTO wardDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateWardDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
