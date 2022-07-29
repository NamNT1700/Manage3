using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OrgTitle
{
    public class ListOrgTitleDTO
    {
        public int Id { get; set; }
        public int? OrgId { get; set; }
        public int? TitleId { get; set; }
        public string Code { get; set; }
    }
}
