using System;

namespace ComLog.Db.Entities
{
    public interface ITrackedEntity
    {
        string ChangeBy { get; set; }
        DateTime? ChangeAt { get; set; }
    }
}