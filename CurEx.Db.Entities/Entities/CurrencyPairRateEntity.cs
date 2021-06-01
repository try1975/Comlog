using System;

namespace CurEx.Db.Entities.Entities
{
    public class CurrencyPairRateEntity : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime RateDate { get; set; }
        public string CurrencyPairId { get; set; }
        public decimal Rate { get; set; }
        public decimal? OpenRate { get; set; }
        public decimal? CloseRate { get; set; }
        public decimal? LowRate { get; set; }
        public decimal? HighRate { get; set; }
        public CurrencyPairEntity CurrencyPair { get; set; }
    }
}