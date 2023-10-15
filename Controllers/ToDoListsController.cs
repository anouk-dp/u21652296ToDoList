using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using u21652296ToDoList.Models;

namespace u21652296ToDoList.Controllers
{
    public class ToDoListsController : Controller
    {
        private ToDoListDBEntities db = new ToDoListDBEntities();

        // GET: ToDoLists
        public async Task<ActionResult> Index()
        {
            var toDoList = db.ToDoList.Include(t => t.ListItem).Include(t => t.ListItemPriority);
            return PartialView(await toDoList.ToListAsync());
        }

        // GET: ToDoLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = await db.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return PartialView(toDoList);
        }

        // GET: ToDoLists/Create
        public ActionResult Create()
        {
            ViewBag.ListItemID = new SelectList(db.ListItem, "ListItemID", "Description");
            ViewBag.PriorityID = new SelectList(db.ListItemPriority, "PriorityID", "PriorityName");
            return PartialView();
        }
    

        // POST: ToDoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskID,ListItemID,DueDate,PriorityID")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                db.ToDoList.Add(toDoList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ListItemID = new SelectList(db.ListItem, "ListItemID", "Description", toDoList.ListItemID);
            ViewBag.PriorityID = new SelectList(db.ListItemPriority, "PriorityID", "PriorityName", toDoList.PriorityID);
            return PartialView(toDoList);
        }

        // GET: ToDoLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = await db.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListItemID = new SelectList(db.ListItem, "ListItemID", "Description", toDoList.ListItemID);
            ViewBag.PriorityID = new SelectList(db.ListItemPriority, "PriorityID", "PriorityName", toDoList.PriorityID);
            return PartialView(toDoList);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,ListItemID,DueDate,PriorityID")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ListItemID = new SelectList(db.ListItem, "ListItemID", "Description", toDoList.ListItemID);
            ViewBag.PriorityID = new SelectList(db.ListItemPriority, "PriorityID", "PriorityName", toDoList.PriorityID);
            return PartialView(toDoList);
        }

        // GET: ToDoLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = await db.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return PartialView(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToDoList toDoList = await db.ToDoList.FindAsync(id);
            db.ToDoList.Remove(toDoList);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}