namespace ComLog.Db.MsSql.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcelBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dt = c.DateTime(storeType: "date"),
                        Bank = c.String(maxLength: 250),
                        Account = c.String(maxLength: 250),
                        AccountType = c.String(maxLength: 250),
                        CurrencyId = c.String(maxLength: 250),
                        Credits = c.Decimal(storeType: "money"),
                        Debits = c.Decimal(storeType: "money"),
                        Charges = c.Decimal(storeType: "money"),
                        FromTo = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        Report = c.String(maxLength: 250),
                        TrType = c.String(maxLength: 250),
                        Splus = c.Decimal(storeType: "money"),
                        Sminus = c.Decimal(storeType: "money"),
                        Ssum = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExcelBooks");
        }
    }
}
