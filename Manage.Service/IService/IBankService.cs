using Manage.Common;
using Manage.Model.DTO.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IBankService
    {
        Task<Response> AddNew(BankDTO bank);
    }
}
