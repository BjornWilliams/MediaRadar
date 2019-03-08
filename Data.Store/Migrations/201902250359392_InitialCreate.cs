namespace Data.Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicationAdActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdPages = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandId = c.Int(nullable: false),
                        BrandName = c.String(maxLength: 500),
                        EstPrintSpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParentCompanyId = c.Int(nullable: false),
                        ParentCompany = c.String(maxLength: 500),
                        ProductCategory = c.String(),
                        PublicationId = c.Int(nullable: false),
                        PublicationName = c.String(maxLength: 500),
                        Month = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PublicationAdActivity");
        }
    }
}
