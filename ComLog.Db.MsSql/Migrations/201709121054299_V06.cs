namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Closed", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Accounts", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Accounts", "ChangeAt", c => c.DateTime());
            AddColumn("dbo.AccountTypes", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.AccountTypes", "ChangeAt", c => c.DateTime());
            AddColumn("dbo.Banks", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Banks", "ChangeAt", c => c.DateTime());
            AddColumn("dbo.Currencies", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Currencies", "ChangeAt", c => c.DateTime());
            AddColumn("dbo.TransactionTypes", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.TransactionTypes", "ChangeAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionTypes", "ChangeAt");
            DropColumn("dbo.TransactionTypes", "ChangeBy");
            DropColumn("dbo.Currencies", "ChangeAt");
            DropColumn("dbo.Currencies", "ChangeBy");
            DropColumn("dbo.Banks", "ChangeAt");
            DropColumn("dbo.Banks", "ChangeBy");
            DropColumn("dbo.AccountTypes", "ChangeAt");
            DropColumn("dbo.AccountTypes", "ChangeBy");
            DropColumn("dbo.Accounts", "ChangeAt");
            DropColumn("dbo.Accounts", "ChangeBy");
            DropColumn("dbo.Accounts", "Closed");
        }
    }
}
