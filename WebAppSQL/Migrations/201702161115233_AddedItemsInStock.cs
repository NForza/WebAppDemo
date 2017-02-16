namespace WebAppSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemsInStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ItemsInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ItemsInStock");
        }
    }
}
