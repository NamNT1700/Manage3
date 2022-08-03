using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.ContractAllowance
{
    public class UpdateContractAllowanceDTO
    {
        public int id { get; set; }
        public UpdateDataAllowance updateData { get; set; }
    }
    public class UpdateDataAllowance
    {
        public double? Money { get; set; }
        public string Activeflg { get; set; }
    }
}
