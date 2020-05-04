using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Identity.Models
{
    public class User : IdentityUser
    {
        public string IdEmployee { get; set; }
    }
}
