namespace ComLog.Dto
{
    public class TransactionTypeDto : IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}