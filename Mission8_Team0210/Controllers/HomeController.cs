using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Team0210.Models;
namespace Mission8_Team0210.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private ToDoContex toDoContext { get; set; }
        public HomeController(ToDoContex x)
        {
            toDoContext = x;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Quadrants() // action for main quadrants page
        {
            return View();
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        [HttpGet]
        public IActionResult ToDo() // Loads the page to add tasks
        {
            ViewBag.Lists = toDoContext.Lists.ToList();
            ViewBag.Categories = toDoContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ToDo(ToDoList toDo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Lists = toDoContext.Lists.ToList();
                ViewBag.Categories = toDoContext.Categories.ToList();
                return View("Quadrants");
            }
            else
            {
                ViewBag.Lists = toDoContext.Lists.ToList();
                ViewBag.Categories = toDoContext.Categories.ToList();
                return View();
            }
        }
        // Edit saved tasks
        public IActionResult Edit(int taskID)
        {
            ViewBag.Categories = toDoContext.Categories.ToList();
            var task = toDoContext.Lists.Single(x => x.TaskId == taskID);
            return View("ToDo", task);
        }
        [HttpPost]
        public IActionResult Edit(ToDoList list) // checks validity of entered edits and returns to correct page
        {
            if (ModelState.IsValid)
            {
                toDoContext.Update(list);
                toDoContext.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Categories = toDoContext.Categories.ToList();
                return View(list);
            }
        }
        [HttpGet]
        public IActionResult Delete(int taskID) // specified page for deleting
        {
            var task = toDoContext.Lists.Single(x => x.TaskId == taskID);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(ToDoList list) // deletes a specified record in the database
        {
            toDoContext.Lists.Remove(list);
            toDoContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }
    }
}