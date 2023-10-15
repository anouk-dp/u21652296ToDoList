using System.Collections.Generic;
using u21652296ToDoList.Models; 

namespace u21652296ToDoList.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ListItemPriority> ListItemPriorities { get; set; }
        public IEnumerable<ListItem> ListItems { get; set; }
        public IEnumerable<ToDoList> ToDoLists { get; set; }
    }
}
