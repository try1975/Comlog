namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ChangeBy = c.String(maxLength: 50),
                        ChangeAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_DailyName");
            
            AddColumn("dbo.Accounts", "DailyId", c => c.Int());
            CreateIndex("dbo.Accounts", "DailyId");
            AddForeignKey("dbo.Accounts", "DailyId", "dbo.DailyNames", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "DailyId", "dbo.DailyNames");
            DropIndex("dbo.DailyNames", "IX_DailyName");
            DropIndex("dbo.Accounts", new[] { "DailyId" });
            DropColumn("dbo.Accounts", "DailyId");
            DropTable("dbo.DailyNames");
        }
    }
}
