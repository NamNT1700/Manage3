using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OrgTitle;
using Manage.Service.IService;

namespace Manage.Service.Service
{
    public class OrgTitleService : IOrgTitleService
    {
        public Task<BaseResponse> AddNew(OrgTitleDTO orgTitleDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAll(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Update(UpdateOrgTitleDTO update)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
