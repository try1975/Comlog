namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "MsDaily01", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "MsDaily01");
        }
    }
}
