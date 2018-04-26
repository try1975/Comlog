using System.Data.Entity;
using ComLog.Db.Entities;
using ComLog.Db.MsSql.Mappings;
using ComLog.Db.MsSql.Migrations;
using Z.EntityFramework.Plus;

namespace ComLog.Db.MsSql
{
    [DbConfigurationType(typeof(ConfigContext))]
    public class WorkContext : DbContext
    {
        static WorkContext()
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               ((WorkContext) context).AuditEntries.AddRange(audit.Entries);
        }

        public WorkContext() : base("name=ComLog")
        {
        }

        public virtual DbSet<ExcelBookEntity> ExcelBooks { get; set; }
        public virtual DbSet<BankEntity> Banks { get; set; }
        public virtual DbSet<AccountTypeEntity> AccountTypes { get; set; }
        public virtual DbSet<CurrencyEntity> Currencies { get; set; }
        public virtual DbSet<TransactionTypeEntity> TransactionTypes { get; set; }
        public virtual DbSet<NewFormTypeEntity> NewFormTypes { get; set; }
        public virtual DbSet<AccountEntity> Accounts { get; set; }
        public virtual DbSet<TransactionEntity> Transactions { get; set; }
        public virtual DbSet<DailyEntity> DailyNames { get; set; }


        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string prefix = "";
            modelBuilder.Configurations.Add(new ExcelBookMap($"{prefix}{nameof(ExcelBooks)}"));
            modelBuilder.Configurations.Add(new BankMap($"{prefix}{nameof(Banks)}"));
            modelBuilder.Configurations.Add(new AccountTypeMap($"{prefix}{nameof(AccountTypes)}"));
            modelBuilder.Configurations.Add(new CurrencyMap($"{prefix}{nameof(Currencies)}"));
            modelBuilder.Configurations.Add(new TransactionTypeMap($"{prefix}{nameof(TransactionTypes)}"));
            modelBuilder.Configurations.Add(new NewFormTypeMap($"{prefix}{nameof(NewFormTypes)}"));
            modelBuilder.Configurations.Add(new AccountMap($"{prefix}{nameof(Accounts)}"));
            modelBuilder.Configurations.Add(new TransactionMap($"{prefix}{nameof(Transactions)}"));
            modelBuilder.Configurations.Add(new DailyMap($"{prefix}{nameof(DailyNames)}"));
        }
    }

    public class ConfigContext : DbConfiguration
    {
        public ConfigContext()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<WorkContext>());
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<WorkContext, Configuration>());
        }
    }
}