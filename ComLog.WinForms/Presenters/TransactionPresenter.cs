using System.Collections.Generic;
using System.Linq;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters.Common;

namespace ComLog.WinForms.Presenters
{
    public class TransactionPresenter : TypedPresenter<TransactionExtDto, int>
    {
        public TransactionPresenter(ITransactionView view, ITransactionDataManager typedDataMаnager,
            IDataMаnager dataMаnager) : base(view, typedDataMаnager, dataMаnager)
        {
            LoadLists();
        }

        private async void LoadLists()
        {
            var accountDtos = await DataMаnager.GetAccounts();
            var accountExtDtos = accountDtos as IList<AccountExtDto> ?? accountDtos.ToList();
            //((ITransactionView)View).AllAccountList = accountExtDtos?.OrderBy(z => z.Name).ThenBy(z => z.BankName).ThenBy(z => z.CurrencyId).ToList();
            ((ITransactionView) View).AllAccountList = accountExtDtos?.Where(z => z.Closed == null).OrderBy(z => z.Name)
                .ThenBy(z => z.BankName).ThenBy(z => z.CurrencyId).ToList();

            ((ITransactionView) View).NotClosedAccountList = accountExtDtos?.Where(z => z.Closed == null)
                .OrderBy(z => z.Name).ThenBy(z => z.BankName).ThenBy(z => z.CurrencyId).ToList();

            var transactionTypeDtos = await DataMаnager.GetTransactionTypes();
            if (transactionTypeDtos != null)
                ((ITransactionView) View).TransactionTypeList =
                    transactionTypeDtos.Select(c => new KeyValuePair<int, string>(c.Id, $"{c.Name}"))
                        .OrderBy(kv => kv.Value)
                        .ToList();
            else
                ((ITransactionView) View).TransactionTypeList = new List<KeyValuePair<int, string>>();

            var newFormTypeDtos = await DataMаnager.GetNewFormTypes();
            if (newFormTypeDtos != null)
                ((ITransactionView)View).NewFormTypeList =
                    newFormTypeDtos.Select(c => new KeyValuePair<int, string>(c.Id, $"{c.Name}"))
                        .OrderBy(kv => kv.Value)
                        .ToList();
            else
                ((ITransactionView)View).NewFormTypeList = new List<KeyValuePair<int, string>>();
        }
    }
}