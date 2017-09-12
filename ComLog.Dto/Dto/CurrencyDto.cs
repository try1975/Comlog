using System;

namespace ComLog.Dto
{
    public class CurrencyDto: IDto<string>, ITrackedDto
    {
        public string Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}