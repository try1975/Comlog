using System;
using System.Collections.Generic;

namespace ComLog.Db.Entities
{
    public class DailyEntity : IEntity<int>, ITrackedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}