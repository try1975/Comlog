using System;

namespace ComLog.Data.Interfaces
{
    public interface ITrackedEntity
    {
        string ChangeBy { get; set; }
        DateTime? ChangeAt { get; set; }
    }
}