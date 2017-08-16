namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExcelBooks", "AccountName", c => c.String(maxLength: 250));
            AddColumn("dbo.ExcelBooks", "AccountTypeName", c => c.String(maxLength: 250));
            CreateIndex("dbo.ExcelBooks", "Dt", name: "IX_ExcelBookDt");
            CreateIndex("dbo.ExcelBooks", "AccountId");
            CreateIndex("dbo.ExcelBooks", "AccountTypeId");
            CreateIndex("dbo.ExcelBooks", "TransactionTypeId");
            CreateIndex("dbo.Transactions", "Dt", name: "IX_TransactionDt");
            AddForeignKey("dbo.ExcelBooks", "AccountId", "dbo.Accounts", "Id");
            AddForeignKey("dbo.ExcelBooks", "AccountTypeId", "dbo.AccountTypes", "Id");
            AddForeignKey("dbo.ExcelBooks", "TransactionTypeId", "dbo.TransactionTypes", "Id");
            DropColumn("dbo.ExcelBooks", "Account");
            DropColumn("dbo.ExcelBooks", "AccountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExcelBooks", "AccountType", c => c.String(maxLength: 250));
            AddColumn("dbo.ExcelBooks", "Account", c => c.String(maxLength: 250));
            DropForeignKey("dbo.ExcelBooks", "TransactionTypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.ExcelBooks", "AccountTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.ExcelBooks", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", "IX_TransactionDt");
            DropIndex("dbo.ExcelBooks", new[] { "TransactionTypeId" });
            DropIndex("dbo.ExcelBooks", new[] { "AccountTypeId" });
            DropIndex("dbo.ExcelBooks", new[] { "AccountId" });
            DropIndex("dbo.ExcelBooks", "IX_ExcelBookDt");
            DropColumn("dbo.ExcelBooks", "AccountTypeName");
            DropColumn("dbo.ExcelBooks", "AccountName");
        }
    }
}
