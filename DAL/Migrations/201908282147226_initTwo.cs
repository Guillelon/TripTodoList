namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initTwo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Items", newName: "TodoItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TodoItems", newName: "Items");
        }
    }
}
