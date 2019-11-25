using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CapstoneFourTaskLisk.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneFourTaskLisk.Controllers
{
    public class CapstoneFourDbController : Controller
    {
        private readonly CapstoneFourDbContext _database;

        public CapstoneFourDbController(CapstoneFourDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewTaskList(TaskList task)
        {
           
                return View(_database.TaskList.ToList());
            
        }

        [HttpGet]
        public IActionResult AddTask()
        {

            return View();
        }

        [HttpPost]

        public IActionResult AddTask(TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                _database.TaskList.Add(tasklist);
                _database.SaveChanges();
                return RedirectToAction("ViewTaskList");
            }
            return View();
        }

        public IActionResult DeleteTask(int id)
        {

            var selectedTask = _database.TaskList.Find(id);
            if (selectedTask != null)
            {
                _database.TaskList.Remove(selectedTask);
                _database.SaveChanges();
            }
            return RedirectToAction("ViewTaskList");

        }







    }
}