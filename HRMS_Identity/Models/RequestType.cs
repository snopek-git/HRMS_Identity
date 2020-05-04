using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class RequestType
    {
        public RequestType()
        {
            Request = new HashSet<Request>();
        }

        public int IdRequestType { get; set; }
        public string Type { get; set; }
        public string Object { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
