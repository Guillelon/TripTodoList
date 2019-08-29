using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TripToDoListDatabaseContext : DbContext
    {
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<Trip> Trip { get; set; }
    }
}
