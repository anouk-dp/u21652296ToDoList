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
    public class ListItemPrioritiesController : Controller
    {
        private ToDoListDBEntities db = new ToDoListDBEntities();

        // GET: ListItemPriorities
        public async Task<ActionResult> Index()
        {
            return PartialView(await db.ListItemPriority.ToListAsync());
        }

        // GET: ListItemPriorities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemPriority listItemPriority = await db.ListItemPriority.FindAsync(id);
            if (listItemPriority == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItemPriority);
        }

        // GET: ListItemPriorities/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: ListItemPriorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PriorityID,PriorityName")] ListItemPriority listItemPriority)
        {
            if (ModelState.IsValid)
            {
                db.ListItemPriority.Add(listItemPriority);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return PartialView(listItemPriority);
        }

        // GET: ListItemPriorities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemPriority listItemPriority = await db.ListItemPriority.FindAsync(id);
            if (listItemPriority == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItemPriority);
        }

        // POST: ListItemPriorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PriorityID,PriorityName")] ListItemPriority listItemPriority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listItemPriority).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(listItemPriority);
        }

        // GET: ListItemPriorities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemPriority listItemPriority = await db.ListItemPriority.FindAsync(id);
            if (listItemPriority == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItemPriority);
        }

        // POST: ListItemPriorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ListItemPriority listItemPriority = await db.ListItemPriority.FindAsync(id);
            db.ListItemPriority.Remove(listItemPriority);
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
