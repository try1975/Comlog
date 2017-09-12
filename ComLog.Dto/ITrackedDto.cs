using System;

namespace ComLog.Dto
{
    public interface ITrackedDto
    {
        string ChangeBy { get; set; }
        DateTime? ChangeAt { get; set; }
    }
}