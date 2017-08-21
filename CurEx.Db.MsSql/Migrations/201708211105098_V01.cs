namespace CurEx.Db.MsSql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyPairRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateDate = c.DateTime(nullable: false, storeType: "date"),
                        CurrencyPairId = c.String(nullable: false, maxLength: 10),
                        Rate = c.Decimal(nullable: false, storeType: "money"),
                        OpenRate = c.Decimal(storeType: "money"),
                        CloseRate = c.Decimal(storeType: "money"),
                        LowRate = c.Decimal(storeType: "money"),
                        HighRate = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyPairs", t => t.CurrencyPairId)
                .Index(t => new { t.RateDate, t.CurrencyPairId }, unique: true, name: "IX_CurRate");
            
            CreateTable(
                "dbo.CurrencyPairs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrencyPairRates", "CurrencyPairId", "dbo.CurrencyPairs");
            DropIndex("dbo.CurrencyPairRates", "IX_CurRate");
            DropTable("dbo.CurrencyPairs");
            DropTable("dbo.CurrencyPairRates");
        }
    }
}
