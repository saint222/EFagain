namespace EFagain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Address", newName: "Addresses");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Shop", newName: "Shops");
            AlterColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Quantity", c => c.String());
            RenameTable(name: "dbo.Shops", newName: "Shop");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Addresses", newName: "Address");
        }
    }
}
