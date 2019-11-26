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
            else
            {
                return View();
            }
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
        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            return View(_database.TaskList.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateTask(TaskList newTask)
        {
            if (ModelState.IsValid)
            {
                TaskList oldTask = _database.TaskList.Find(newTask.TaskId);
                oldTask.TaskDescription = newTask.TaskDescription;
                oldTask.DueDate = newTask.DueDate;
                oldTask.Complete = newTask.Complete;


                _database.Entry(oldTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _database.Update(oldTask);
                _database.SaveChanges();

            }
            return RedirectToAction("ViewTaskList");
        }








    }
}