namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "ChangeBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Transactions", "ChangeAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "ChangeAt");
            DropColumn("dbo.Transactions", "ChangeBy");
        }
    }
}
