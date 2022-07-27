using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OrgTitle;

namespace Manage.Service.IService
{
    public interface IOrgTitleService
    {
        Task<BaseResponse> AddNew(OrgTitleDTO orgTitleDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOrgTitleDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
