﻿namespace ComLog.Dto
{
    public class BankDto : IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}