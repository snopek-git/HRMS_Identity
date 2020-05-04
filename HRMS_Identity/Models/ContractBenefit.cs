using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class ContractBenefit
    {
        public int IdBenefitContract { get; set; }
        public int IdBenefit { get; set; }
        public int IdContract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Benefit IdBenefitNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
    }
}
