using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace u21652296ToDoList.Models
{
    public class ListItemsController : Controller
    {
        private ToDoListDBEntities db = new ToDoListDBEntities();

        // GET: ListItems
        public async Task<ActionResult> Index()
        {
            return PartialView(await db.ListItem.ToListAsync());
        }

        // GET: ListItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = await db.ListItem.FindAsync(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItem);
        }

        // GET: ListItems/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: ListItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ListItemID,Description")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                db.ListItem.Add(listItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return PartialView(listItem);
        }

        // GET: ListItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = await db.ListItem.FindAsync(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItem);
        }

        // POST: ListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ListItemID,Description")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(listItem);
        }

        // GET: ListItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = await db.ListItem.FindAsync(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return PartialView(listItem);
        }

        // POST: ListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ListItem listItem = await db.ListItem.FindAsync(id);
            db.ListItem.Remove(listItem);
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
