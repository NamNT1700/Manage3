using Manage.Common;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Manage.Service.IService
{
    public interface IBankService
    {
        Task<BaseResponse> AddNew(BankDTO bank);
        Task<BaseResponse> AddNewBank(BankDTO bank);
        Task<BaseResponse> AddNewBranch(BankBranchDTO bankBranch);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateBankDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
