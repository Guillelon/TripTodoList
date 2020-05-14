namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInTrip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "Description");
        }
    }
}
