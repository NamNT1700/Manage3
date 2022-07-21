using System;

namespace Manage.Model.DTO.Bank
{
    public class UpdateBankDTO
    {
        public int Id { get; set; }
        public UpdateBank updateData { get; set; }
    }
    public class UpdateBank
    {
        public string Name { get; set; }
        public string Activeflg { get; set; }
    }
}
