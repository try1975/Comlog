using System;

namespace ComLog.Dto
{
    public class BankDto : IDto<int>, ITrackedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Closed { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}