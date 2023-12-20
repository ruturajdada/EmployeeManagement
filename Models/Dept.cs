using System;
using System.Collections.Generic;

namespace MVC_CRUD_Challange.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
