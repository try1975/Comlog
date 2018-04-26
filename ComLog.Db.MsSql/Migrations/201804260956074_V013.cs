namespace ComLog.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V013 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewFormTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ChangeBy = c.String(maxLength: 50),
                        ChangeAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_TransactionTypeName");
            
            AddColumn("dbo.Transactions", "NewFormTypeId", c => c.Int());
            CreateIndex("dbo.Transactions", "NewFormTypeId");
            AddForeignKey("dbo.Transactions", "NewFormTypeId", "dbo.NewFormTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "NewFormTypeId", "dbo.NewFormTypes");
            DropIndex("dbo.NewFormTypes", "IX_TransactionTypeName");
            DropIndex("dbo.Transactions", new[] { "NewFormTypeId" });
            DropColumn("dbo.Transactions", "NewFormTypeId");
            DropTable("dbo.NewFormTypes");
        }
    }
}
