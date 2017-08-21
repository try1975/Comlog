using System.Collections.Generic;

namespace CurEx.Db.Entities.Entities
{
    public class CurrencyPairEntity : IEntity<string>
    {
        public string Id { get; set; }
        public ICollection<CurrencyPairRateEntity> CurrencyPairRates { get; set; }
    }
}