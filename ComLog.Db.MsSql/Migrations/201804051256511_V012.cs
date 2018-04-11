namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V012 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Pmrq", c => c.String(maxLength: 50));
            AddColumn("dbo.Transactions", "Dc", c => c.Decimal(storeType: "money"));
            DropColumn("dbo.Transactions", "Dc");
            Sql(@"ALTER TABLE [dbo].[Transactions] ADD [Dc] AS ((isnull([Credits],(0))+isnull([Debits],(0))));");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Dc");
            DropColumn("dbo.Transactions", "Pmrq");
        }
    }
}
