using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult ViewTaskList()
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







    }
}