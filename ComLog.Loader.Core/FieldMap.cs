using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ComLog.Db.Entities;
using Newtonsoft.Json;

namespace ComLog.Loader.Core
{
    public static class FieldMap
    {
        public static readonly Dictionary<string, string> Map = new Dictionary<string, string>();
        static FieldMap()
        {
            Map["DT"] = nameof(ExcelBookEntity.Dt);
            Map["Bank"] = nameof(ExcelBookEntity.BankName);
            Map["Account"] = nameof(ExcelBookEntity.AccountName);
            Map["Type"] = nameof(ExcelBookEntity.AccountTypeName);
            Map["Currency"] = nameof(ExcelBookEntity.CurrencyId);
            Map["Credits"] = nameof(ExcelBookEntity.Credits);
            Map["Debits"] = nameof(ExcelBookEntity.Debits);
            Map["Charges"] = nameof(ExcelBookEntity.Charges);
            Map["From"] = nameof(ExcelBookEntity.FromTo);
            Map["Description"] = nameof(ExcelBookEntity.Description);
            Map["Report"] = nameof(ExcelBookEntity.Report);
            Map["TrType"] = nameof(ExcelBookEntity.TrType);
            Map["$"] = nameof(ExcelBookEntity.Splus);
            Map["$-"] = nameof(ExcelBookEntity.Sminus);
            Map["S"] = nameof(ExcelBookEntity.Ssum);

            var pathPrefix = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)}\\ComLogTransactions.json";
            var path = new Uri($"{pathPrefix}").LocalPath;
            try
            {
                var json = JsonConvert.SerializeObject(Map);
                File.WriteAllText(path, json);
            }
            catch
            {
                // ignored
            }
        }
    }
}