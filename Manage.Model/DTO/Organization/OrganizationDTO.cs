using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Organization
{
    public class OrganizationDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? OrderNumber { get; set; }
    }
}
