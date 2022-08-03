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
        public string Allwance { get; set; }
        [Required]
        public double? Money { get; set; }
        [Required]
        public string Contract { get; set; }
    }
}
