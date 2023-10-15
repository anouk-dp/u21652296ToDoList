using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using u21652296ToDoList.Models;

namespace u21652296ToDoList.Models
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var viewModel = new IndexViewModel
            {
                ListItemPriorities = GetListItemPriorities(),
                ListItems = GetListItems(),
                ToDoLists = GetToDoLists()
            };

            return View(viewModel);


        }
        private IEnumerable<ListItemPriority> GetListItemPriorities()
        {
            using (var context = new ToDoListDBEntities())
            {
                return context.ListItemPriority.ToList();
            }
        }

        private IEnumerable<ListItem> GetListItems()
        {
            using (var context = new ToDoListDBEntities())
            {
                return context.ListItem.ToList();
            }
        }

        private IEnumerable<ToDoList> GetToDoLists()
        {
            using (var context = new ToDoListDBEntities())
            {
                return context.ToDoList
                              .Include(t => t.ListItem)
                              .Include(t => t.ListItemPriority)
                              .ToList();
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}