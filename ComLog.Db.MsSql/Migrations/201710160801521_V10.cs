namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Ord", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "Ord");
        }
    }
}
