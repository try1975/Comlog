namespace ComLog.Dto
{
    public class AccountTypeDto:IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}