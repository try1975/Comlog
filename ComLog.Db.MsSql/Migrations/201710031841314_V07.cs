namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccountNumber", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "AccountNumber");
        }
    }
}
