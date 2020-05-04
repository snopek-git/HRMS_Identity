using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class ContractType
    {
        public ContractType()
        {
            Contract = new HashSet<Contract>();
        }

        public int IdContractType { get; set; }
        public string ContractType1 { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
