using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OrgTitle
{
    public class UpdateOrgTitleDTO
    {
        public int id { get; set; }
        public UpdateOrgTitle updateData { get; set; }
    }
    public class UpdateOrgTitle
    {
        public string Name { get; set; }
        public int? OrgId { get; set; }
        public int? TitleId { get; set; }
        public string Activeflg { get; set; }
    }
}
