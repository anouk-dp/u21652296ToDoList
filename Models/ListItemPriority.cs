//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace u21652296ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListItemPriority
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListItemPriority()
        {
            this.ToDoList = new HashSet<ToDoList>();
        }
    
        public int PriorityID { get; set; }
        public string PriorityName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToDoList> ToDoList { get; set; }
    }
}