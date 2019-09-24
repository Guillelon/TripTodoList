namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDoneToTheList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "Done", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "Done");
        }
    }
}
