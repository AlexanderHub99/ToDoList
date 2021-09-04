using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.MyToDoLists.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult NoId()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(MyToDoList myToDoList)
         {

             db.MyToDoLists.Add(myToDoList);
            await db.SaveChangesAsync();
            
           return RedirectToAction("Index");

         }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            MyToDoList b = db.MyToDoLists.Find(id);
            if (b == null)
            {
                //return RedirectToAction("Delete");
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MyToDoList b = db.MyToDoLists.Find(id);
            if (b == null)
            {
                //return RedirectToAction("Delete");
            }
            db.MyToDoLists.Remove(b);
            db.SaveChanges();
            
            return RedirectToAction("Delete");
        }
    }

}
