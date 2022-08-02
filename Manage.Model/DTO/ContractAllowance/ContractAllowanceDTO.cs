using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.ContractAllowance
{
    public class ContractAllowanceDTO
    {
        [Required]
        public int? AllwanceId { get; set; }
        [Required]
        public double? Money { get; set; }
        [Required]
        public int? ContractId { get; set; }
    }
}
