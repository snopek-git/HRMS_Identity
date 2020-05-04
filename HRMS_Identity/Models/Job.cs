using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Job
    {
        public Job()
        {
            Employee = new HashSet<Employee>();
        }

        public int IdJob { get; set; }
        public string JobName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
