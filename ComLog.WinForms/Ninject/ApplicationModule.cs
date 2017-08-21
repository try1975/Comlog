using ComLog.WinForms.Controls;
using ComLog.WinForms.Data;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using Ninject.Modules;

namespace ComLog.WinForms.Ninject
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataMаnager>().To<DataMаnager>().InSingletonScope();
            Bind<IComLogControl>().To<ComLogControl>().InSingletonScope();

            Bind<IBankView>().To<BankControl>();
            Bind<IBankDataMаnager>().To<BankDataMаnager>().InSingletonScope();

            //Bind<IBankAccountView>().To<BankAccountControl>();
            //Bind<IBankAccountDataManager>().To<BankAccountDataManager>().InSingletonScope();

            //Bind<IClientView>().To<ClientControl>();
            //Bind<IClientDataManager>().To<ClientDataManager>().InSingletonScope();

            //Bind<IClientAccountView>().To<ClientAccountControl>();
            //Bind<IClientAccountDataManager>().To<ClientAccountDataManager>().InSingletonScope();

            //Bind<ICardView>().To<CardControl>();
            //Bind<ICardDataMаnager>().To<CardDataMаnager>().InSingletonScope();

            //Bind<IRequestView>().To<RequestControl>();
            //Bind<IRequestDataManager>().To<RequestDataManager>().InSingletonScope();

            //Bind<IMessageView>().To<MessageControl>();
            //Bind<IMessageDataManager>().To<MessageDataManager>().InSingletonScope();

            //Bind<ITransferOutInfoView>().To<TransferOutInfoControl>();
            //Bind<ITransferOutInfoDataManager>().To<TransferOutInfoDataManager>().InSingletonScope();

            //Bind<ITransactionView>().To<TransactionControl>();
            //Bind<ITransactionDataManager>().To<TransactionDataManager>().InSingletonScope();

            //Bind<IStatementView>().To<StatementControl>();
            //Bind<IStatementDataManager>().To<StatementDataManager>().InSingletonScope();

            //Bind<IStandingOrderView>().To<StandingOrderControl>();
            //Bind<IStandingOrderDataManager>().To<StandingOrderDataManager>().InSingletonScope();

            //Bind<IDirectDebitView>().To<DirectDebitControl>();
            //Bind<IDirectDebitDataManager>().To<DirectDebitDataManager>().InSingletonScope();
        }
    }
}