using System;
using System.Collections.Generic;

namespace MVC_CRUD_Challange.Models
{
    public partial class Employee
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? DeptId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Dept? Dept { get; set; }
    }
}
