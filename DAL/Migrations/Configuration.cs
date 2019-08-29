namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Repositories.TripToDoListDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Repositories.TripToDoListDatabaseContext context)
        {
            if (!context.Trip.Any())
            {
                var tulisitoTrip = new Trip();
                tulisitoTrip.Name = "Tulusito 2019";
                context.Trip.Add(tulisitoTrip);
                context.SaveChanges();
            }
        }
    }
}
