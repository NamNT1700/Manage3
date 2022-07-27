using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.BankBranch;

namespace Manage.Service.IService
{
    public interface IBankBranchService
    {
        Task<BaseResponse> AddNew(BankBranchDTO bankBranch);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateBankBranchDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
