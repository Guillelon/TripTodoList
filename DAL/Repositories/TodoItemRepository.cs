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

        public IList<TodoItem> GetTodoItems()
        {
            var todoItems = _context.TodoItem.OrderByDescending(t => t.Id).ToList();
            return todoItems;
        }

        public TodoItem AddTodoItem(TodoItem model)
        {
            var trip = _context.Trip.FirstOrDefault();
            model.CreatedDate = DateTime.Now;
            model.TripId = trip.Id;
            _context.TodoItem.Add(model);
            _context.SaveChanges();
            return model;
        }

        public TodoItem GetTodoItem(int id)
        {
            return _context.TodoItem.Where(i => i.Id == id).FirstOrDefault();
        }
    }
}
