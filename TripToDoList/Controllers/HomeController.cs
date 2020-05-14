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
            var trips = _repo.GetTrips();
            var viewModel = new TripViewModels();
            viewModel.NewTrip = new Trip();
            viewModel.Trips = trips;
            if (TempData["Success"] !=null)
                ViewBag.Success = TempData["Success"];
            if (TempData["WarningMessage"] != null)
                ViewBag.WarningMessage = TempData["WarningMessage"];
            return View(viewModel);
        }

        public ActionResult AddTrip(Trip NewTrip)
        {
            if(NewTrip.Name != null && NewTrip.Name.Length > 0)
            {
                _repo.AddTrip(NewTrip);
                TempData["Success"] = "Trip was saved!";
                return RedirectToAction("Trip", new { id = NewTrip.Id });
            }
            {
                TempData["WarningMessage"] = "yes";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Trip(int id)
        {
            var viewmodel = new TodoItemsDashboardViewModel();
            viewmodel.NewTodoItem = new TodoItem() { TripId = id };
            viewmodel.Trip = _repo.GetTrip(id);
            viewmodel.TodoItems = _repo.GetTodoItems(id);
            if (TempData["Success"] != null)
                ViewBag.Success = TempData["Success"];
            if (TempData["WarningMessage"] != null)
                ViewBag.WarningMessage = TempData["WarningMessage"];
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddTodoItem(TodoItem NewTodoItem)
        {
            var viewmodel = new TodoItemsDashboardViewModel();
            if (NewTodoItem.Title !=null && NewTodoItem.Description != null && NewTodoItem.Type != null)
            {
                _repo.AddTodoItem(NewTodoItem);
                TempData["Success"] = "Awesome thing TODO saved!";
                return RedirectToAction("Trip", new { id = NewTodoItem.TripId });
            }
            else
            {
                TempData["WarningMessage"] = "yes";
                return RedirectToAction("Trip", new { id = NewTodoItem.TripId });
            }
        }

        public ActionResult Details(int id)
        {
            var item = _repo.GetTodoItem(id);
            return PartialView("_TodoItemDetail", item);
        }

        public ActionResult MarkAsDone(int id)
        {
            var item = _repo.MarkAsDone(id);
            TempData["Success"] = "Item Marked as done";
            return RedirectToAction("Trip", new { id = item.TripId });
        }

        public ActionResult MarkTodo(int id)
        {
            var item = _repo.MarkTODO(id);
            TempData["Success"] = "Item Marked TODO";
            return RedirectToAction("Trip", new { id = item.TripId });
        }
    }
}