namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V014 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "WeekDt", c => c.DateTime());
            AddColumn("dbo.TransactionTypes", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionTypes", "IsActive");
            DropColumn("dbo.Transactions", "WeekDt");
        }
    }
}
