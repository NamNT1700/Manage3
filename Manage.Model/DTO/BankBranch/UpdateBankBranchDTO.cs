using System;

namespace Manage.Model.DTO.BankBranch
{
    public class UpdateBankBranchDTO
    {
        public int Id { get; set; }
        public UpdateData updateData { get; set; }
    }
    public class UpdateData
    {
        public string Address { get; set; }
        public int? BankId { get; set; }
        public bool? Activeflg { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
