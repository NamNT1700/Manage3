using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.ContractualBenefit
{
    public class UpdateContractualBenefitDTO
    {
        public int id { get; set; }
        public UpdateContractualBenefit updateData { get; set; }
    }
    public class UpdateContractualBenefit
    {
        public int? WelfaceId { get; set; }
        public double? Money { get; set; }
        public int? ContractId { get; set; }
        public string Activeflg { get; set; }
    }
}
