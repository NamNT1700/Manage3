﻿using Manage.Common;
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
        Task<Response> AddNewBank(BankDTO bank);
        Task<Response> AddNewBranch(BankBranchDTO bankBranch);
        Task<Response> GetAll(BaseRequest request);
        Task<Response> GetById(int id);
        Task<Response> Update(UpdateBankDTO update);
        Task<Response> Delete(List<int> ids);
    }
}
