namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V08 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Balance", c => c.Decimal(storeType: "money"));
            DropColumn("dbo.Accounts", "AccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "AccountNumber", c => c.String(maxLength: 250));
            DropColumn("dbo.Accounts", "Balance");
        }
    }
}
