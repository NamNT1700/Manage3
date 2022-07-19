using System;

namespace Manage.Model.DTO.BankBranch
{
    public class BankBranchDTO
    {
        public string Address { get; set; }
        public int? BankId { get; set; }
        public bool? Activeflg { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
