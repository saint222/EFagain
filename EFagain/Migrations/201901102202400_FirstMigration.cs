namespace EFagain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        BuildingNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.String(),
                        Shop_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Shop", t => t.Shop_ID)
                .Index(t => t.Shop_ID);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .Index(t => t.Address_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Shop_ID", "dbo.Shop");
            DropForeignKey("dbo.Shop", "Address_ID", "dbo.Address");
            DropIndex("dbo.Shop", new[] { "Address_ID" });
            DropIndex("dbo.Product", new[] { "Shop_ID" });
            DropTable("dbo.Shop");
            DropTable("dbo.Product");
            DropTable("dbo.Address");
        }
    }
}
