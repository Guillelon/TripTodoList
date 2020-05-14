using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<TodoItem> TodoItems { get; set; }

        public Trip()
        {
            TodoItems = new List<TodoItem>();
            CreatedDate = DateTime.Now;
        }
    }
}
