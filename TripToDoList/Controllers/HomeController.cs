using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripToDoList.ViewModels;

namespace TripToDoList.Controllers
{
    public class HomeController : Controller
    {
        private TodoItemRepository _repo;

        public HomeController()
        {
            _repo = new TodoItemRepository();
        }

        public ActionResult Index()
        {
            var viewmodel = new TodoItemsDashboardViewModel();
            viewmodel.NewTodoItem = new TodoItem();

            viewmodel.TodoItems = _repo.GetTodoItems();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(TodoItem NewTodoItem)
        {
            var viewmodel = new TodoItemsDashboardViewModel();
            viewmodel.TodoItems = _repo.GetTodoItems();

            if (NewTodoItem.Title !=null && NewTodoItem.Description != null && NewTodoItem.Type != null)
            {
                _repo.AddTodoItem(NewTodoItem);
                ViewBag.Success = "yes";
            }
            else
            {
                viewmodel.NewTodoItem = NewTodoItem;
                ViewBag.WarningMessage = "yes";
            }
            return View(viewmodel); ;
        }
    }
}