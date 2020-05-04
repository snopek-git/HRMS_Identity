using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class AvailableAbsence
    {
        public int IdAvailableAbsence { get; set; }
        public decimal AvailableDays { get; set; }
        public int IdAbsenceType { get; set; }
        public int IdEmployee { get; set; }
        public decimal UsedAbsence { get; set; }

        public virtual AbsenceType IdAbsenceTypeNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
