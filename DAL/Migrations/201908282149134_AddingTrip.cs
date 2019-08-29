namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTrip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TodoItems", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TodoItems", "TripId", c => c.Int(nullable: false));
            CreateIndex("dbo.TodoItems", "TripId");
            AddForeignKey("dbo.TodoItems", "TripId", "dbo.Trips", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "TripId", "dbo.Trips");
            DropIndex("dbo.TodoItems", new[] { "TripId" });
            DropColumn("dbo.TodoItems", "TripId");
            DropColumn("dbo.TodoItems", "CreatedDate");
            DropTable("dbo.Trips");
        }
    }
}
