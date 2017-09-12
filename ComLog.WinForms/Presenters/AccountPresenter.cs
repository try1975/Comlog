using System.Collections.Generic;
using System.Linq;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters.Common;

namespace ComLog.WinForms.Presenters
{
    public class AccountPresenter : TypedPresenter<AccountExtDto, int>
    {
        public AccountPresenter(IAccountView view, IAccountDataManager typedDataMаnager,
            IDataMаnager dataMаnager) : base(view, typedDataMаnager, dataMаnager)
        {
            LoadLists();
        }

        private async void LoadLists()
        {
            var currencyDtos = await DataMаnager.GetCurrencies();
            if (currencyDtos != null)
            {
                var currencies = currencyDtos.ToList();
                ((IAccountView) View).CurrencyList =
                    currencies.Select(c => new KeyValuePair<string, string>(c.Id, c.Id))
                        .ToList();
            }
            else
            {
                ((IAccountView) View).CurrencyList = new List<KeyValuePair<string, string>>();
            }

            var bankDtos = await DataMаnager.GetBanks();
            if (bankDtos != null)
            {
                var banks = bankDtos.ToList();
                ((IAccountView) View).BankList =
                    banks.Select(c => new KeyValuePair<int, string>(c.Id, c.Name))
                        .OrderBy(kv => kv.Value)
                        .ToList();
            }
            else
            {
                ((IAccountView) View).BankList = new List<KeyValuePair<int, string>>();
            }
        }
    }
}