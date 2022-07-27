using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.Organization;

namespace Manage.Service.IService
{
    public interface IOrganizationService
    {
        Task<BaseResponse> AddNew(OrganizationDTO organizationDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOrganizationDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
