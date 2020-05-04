using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Overtime
    {
        public int IdOvertime { get; set; }
        public DateTime ToBeSettledBefore { get; set; }
        public decimal Hours { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
