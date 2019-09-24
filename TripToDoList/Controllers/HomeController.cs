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
            if (TempData["Success"] !=null)
                ViewBag.Success = TempData["Success"];
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(TodoItem NewTodoItem)
        {
            var viewmodel = new TodoItemsDashboardViewModel();
            if (NewTodoItem.Title !=null && NewTodoItem.Description != null && NewTodoItem.Type != null)
            {
                _repo.AddTodoItem(NewTodoItem);
                TempData["Success"] = "TODO item saved!";
                return RedirectToAction("Index");
            }
            else
            {
                viewmodel.NewTodoItem = NewTodoItem;
                ViewBag.WarningMessage = "yes";
                viewmodel.TodoItems = _repo.GetTodoItems();
                return View(viewmodel); ;
            }
        }

        public ActionResult Details(int id)
        {
            var item = _repo.GetTodoItem(id);
            return PartialView("_TodoItemDetail", item);
        }

        public ActionResult MarkAsDone(int id)
        {
            _repo.MarkAsDone(id);
            TempData["Success"] = "Item Marked as done";
            return RedirectToAction("Index");
        }

        public ActionResult MarkTodo(int id)
        {
            _repo.MarkTODO(id);
            TempData["Success"] = "Item Marked TODO";
            return RedirectToAction("Index");
        }
    }
}