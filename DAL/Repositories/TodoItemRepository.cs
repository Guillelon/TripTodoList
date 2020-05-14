using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TodoItemRepository
    {
        private TripToDoListDatabaseContext _context;

        public TodoItemRepository()
        {
            _context = new TripToDoListDatabaseContext();
        }

        public IList<Trip> GetTrips()
        {
            var trips = _context.Trip.ToList();
            return trips;
        }

        public Trip AddTrip(Trip trip)
        {
            _context.Trip.Add(trip);
            _context.SaveChanges();
            return trip;    
        }

        public Trip GetTrip(int id)
        {
            var trip = _context.Trip.Where(t => t.Id == id).FirstOrDefault();
            return trip;
        }

        public IList<TodoItem> GetTodoItems(int id)
        {
            var todoItems = _context.TodoItem.Where(t=> t.TripId == id).OrderByDescending(t => t.Id).ToList();
            return todoItems;
        }

        public TodoItem AddTodoItem(TodoItem model)
        {
            model.CreatedDate = DateTime.Now;
            _context.TodoItem.Add(model);
            _context.SaveChanges();
            return model;
        }

        public TodoItem GetTodoItem(int id)
        {
            return _context.TodoItem.Where(i => i.Id == id).FirstOrDefault();
        }

        public TodoItem MarkAsDone(int id)
        {
            var item = _context.TodoItem.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
            {
                item.Done = true;
                _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return item;
        }

        public TodoItem MarkTODO(int id)
        {
            var item = _context.TodoItem.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
            {
                item.Done = false;
                _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return item;
        }
    }
}
