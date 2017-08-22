namespace ComLog.Common
{
    public static class ComLogConstants
    {
        public static class ClientAppApi
        {
            public const string ApiSegmentName = "api/";

            public const string Accounts = ApiSegmentName + nameof(Accounts);
            public const string AccountTypes = ApiSegmentName + nameof(AccountTypes);
            public const string Banks = ApiSegmentName + nameof(Banks);
            public const string Currencies = ApiSegmentName + nameof(Currencies);
            public const string Transactions = ApiSegmentName + nameof(Transactions);
            public const string TransactionTypes = ApiSegmentName + nameof(TransactionTypes);

        }
    }
}
