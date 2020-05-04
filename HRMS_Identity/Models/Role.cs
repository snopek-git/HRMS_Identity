using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        public int IdRole { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
