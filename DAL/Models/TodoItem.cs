using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Done { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
