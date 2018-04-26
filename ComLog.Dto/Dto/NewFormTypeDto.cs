using System;

namespace ComLog.Dto
{
    public class NewFormTypeDto : IDto<int>, ITrackedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}