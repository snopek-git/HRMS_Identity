using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Request
    {
        public int IdRequest { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantityRequested { get; set; }
        public int IdRequestType { get; set; }
        public int IdRequestStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CommentManager { get; set; }
        public string CommentEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual RequestStatus IdRequestStatusNavigation { get; set; }
        public virtual RequestType IdRequestTypeNavigation { get; set; }
    }
}
