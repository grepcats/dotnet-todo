using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;



namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext _db;
        public ItemsController(ToDoListContext db)
        {
            _db = db;
        }

        public IActionResult Delete(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            _db.Items.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<Item> model = _db.Items.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
    }
}