using Manage.Common;
using Manage.Model.DTO.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IContractService
    {
        Task<BaseResponse> AddNew(ContractDTO bank);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateContractDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
