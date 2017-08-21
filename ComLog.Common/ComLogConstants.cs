namespace ComLog.Common
{
    public static class ComLogConstants
    {
        public static class ClientAppApi
        {
            public const string ApiSegmentName = "api/";

            public const string Banks = ApiSegmentName + nameof(Banks);
            public const string BankAccounts = ApiSegmentName + nameof(BankAccounts);
            public const string Currencies = ApiSegmentName + nameof(Currencies);
            public const string Transactions = ApiSegmentName + nameof(Transactions);
        }
    }
}
