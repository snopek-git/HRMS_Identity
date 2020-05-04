using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Benefit
    {
        public Benefit()
        {
            ContractBenefit = new HashSet<ContractBenefit>();
        }

        public int IdBenefit { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ContractBenefit> ContractBenefit { get; set; }
    }
}
