using Manage.Common;
using Manage.Model.DTO.Allwance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IAllwanceService
    {
        Task<Response> AddNew(AllwanceDTO allwance);
        Task<Response> GetAll(Request request);
        Task<Response> GetById(int id);
    }
}
