using System;
using System.Collections.Generic;

namespace MVC_CRUD_Challange.Models
{
    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public int? PinCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
