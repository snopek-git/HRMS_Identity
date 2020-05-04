using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class ContractStatus
    {
        public ContractStatus()
        {
            Contract = new HashSet<Contract>();
        }

        public int IdContractStatus { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
