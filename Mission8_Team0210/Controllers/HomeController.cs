using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission8_Team0210.Models;

namespace Mission8_Team0210.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContex toDoContext { get; set; }

        public HomeController(ToDoContex x)
        {
            toDoContext = x;
        }

        // Home View
        public IActionResult Index()
        {
            return View();
        }

        // Return the quadrant view with all tasks
        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = toDoContext.Lists.Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        // Make edits to existing tasks
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Categories = toDoContext.Categories.ToList();

                var task = toDoContext.Lists.Single(x => x.TaskId == id);

                return View("Edit", task);
            }
            else
            {
                ViewBag.Categories = toDoContext.Categories.ToList();
                return View();
            }
        }

        // Update changes in the database
        [HttpPost]
        public IActionResult Edit(ToDoList toDo)
        {
            toDoContext.Update(toDo);
            toDoContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        // Return view with form to add more tasks
        [HttpGet]
        public IActionResult ToDo()
        {
            ViewBag.Categories = toDoContext.Categories.ToList();
            return View();
        }

        // Add new task to database
        [HttpPost]
        public IActionResult ToDo(ToDoList toDo)
        {
            if (ModelState.IsValid)
            {
                toDoContext.Add(toDo);
                toDoContext.SaveChanges();
                return View("Quadrants", toDo);
            }
            else
            {
                ViewBag.Categories = toDoContext.Categories.ToList();
                return View();
            }
        }

        // Confirmation for deleting tasks
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var toDo = toDoContext.Lists.Single(x => x.TaskId == id);
            return View(toDo);
        }

        // Delete task from database
        [HttpPost]
        public IActionResult Delete(ToDoList toDo)
        {
            toDoContext.Lists.Remove(toDo);
            toDoContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }
    }
}