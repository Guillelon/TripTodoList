using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripToDoList.ViewModels
{
    public class TodoItemsDashboardViewModel
    {
        public TodoItem NewTodoItem { get; set; }
        public IList<TodoItem> TodoItems { get; set; }

        public IList<string> PossibleTypes { get; set; }

        public TodoItemsDashboardViewModel()
        {
            PossibleTypes = new List<string>();
            PossibleTypes.Add("Food");
            PossibleTypes.Add("Sexy Time");
            PossibleTypes.Add("Entertainment");
            PossibleTypes.Add("Night Out");
        }
    }

    public static class TodoItemTypes
    {
        public static string Food = "Food";
        public static string SexyTime = "Sexy Time";
        public static string Entertainment = "Entertainment";
        public static string NightOut = "Night Out";
    }
}
