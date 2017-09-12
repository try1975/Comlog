using System;
using System.Collections.Generic;

namespace ComLog.Db.Entities
{
    public class AccountTypeEntity : IEntity<int>, ITrackedEntity
    {
        public string Name { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
        public ICollection<ExcelBookEntity> ExcelBooks { get; set; }
        public int Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}