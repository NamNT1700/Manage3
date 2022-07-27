using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.ContractualBenefit;

namespace Manage.Service.IService
{
    public interface IContractualBenefitService
    {
        Task<BaseResponse> AddNew(ContractualBenefitDTO contractualBenefitDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateContractualBenefitDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
