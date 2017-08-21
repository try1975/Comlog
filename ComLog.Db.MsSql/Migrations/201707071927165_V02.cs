namespace ComLog.Db.MsSql.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        BankId = c.Int(nullable: false),
                        CurrencyId = c.String(nullable: false, maxLength: 10),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.BankId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_AccountTypeName");
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Closed = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_BankName");
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dt = c.DateTime(nullable: false, storeType: "date"),
                        BankId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        TransactionTypeId = c.Int(),
                        CurrencyId = c.String(nullable: false, maxLength: 10),
                        Credits = c.Decimal(storeType: "money"),
                        Debits = c.Decimal(storeType: "money"),
                        Charges = c.Decimal(storeType: "money"),
                        FromTo = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        UsdCredits = c.Decimal(storeType: "money"),
                        UsdDebits = c.Decimal(storeType: "money"),
                        Report = c.String(maxLength: 250),
                        Dcc = c.Decimal(storeType: "money"),
                        UsdDcc = c.Decimal(storeType: "money"),
                        TransactionDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeId)
                .Index(t => t.BankId)
                .Index(t => t.AccountId)
                .Index(t => t.TransactionTypeId)
                .Index(t => t.CurrencyId);

            DropColumn("dbo.Transactions", "Dcc");
            Sql(@"ALTER TABLE [dbo].[Transactions] ADD [Dcc] AS ((isnull([Credits],(0))+isnull([Debits],(0)))+isnull([Charges],(0)));");
            DropColumn("dbo.Transactions", "UsdDcc");
            Sql(@"ALTER TABLE [dbo].[Transactions] ADD [UsdDcc] AS (isnull([UsdCredits],(0))+isnull([UsdDebits],(0)));");

            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_TransactionTypeName");
            
            AddColumn("dbo.ExcelBooks", "BankName", c => c.String(maxLength: 250));
            AddColumn("dbo.ExcelBooks", "BankId", c => c.Int());
            AddColumn("dbo.ExcelBooks", "AccountId", c => c.Int());
            AddColumn("dbo.ExcelBooks", "AccountTypeId", c => c.Int());
            AddColumn("dbo.ExcelBooks", "TransactionTypeId", c => c.Int());
            CreateIndex("dbo.ExcelBooks", "BankId");
            AddForeignKey("dbo.ExcelBooks", "BankId", "dbo.Banks", "Id");
            DropColumn("dbo.ExcelBooks", "Bank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExcelBooks", "Bank", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Transactions", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.ExcelBooks", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.TransactionTypes", "IX_TransactionTypeName");
            DropIndex("dbo.Transactions", new[] { "CurrencyId" });
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Transactions", new[] { "BankId" });
            DropIndex("dbo.ExcelBooks", new[] { "BankId" });
            DropIndex("dbo.Banks", "IX_BankName");
            DropIndex("dbo.AccountTypes", "IX_AccountTypeName");
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyId" });
            DropIndex("dbo.Accounts", new[] { "BankId" });
            DropColumn("dbo.ExcelBooks", "TransactionTypeId");
            DropColumn("dbo.ExcelBooks", "AccountTypeId");
            DropColumn("dbo.ExcelBooks", "AccountId");
            DropColumn("dbo.ExcelBooks", "BankId");
            DropColumn("dbo.ExcelBooks", "BankName");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Currencies");
            DropTable("dbo.Transactions");
            DropTable("dbo.Banks");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Accounts");
        }
    }
}
