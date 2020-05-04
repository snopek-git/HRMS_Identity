using System;
using System.Collections.Generic;

namespace HRMS_Identity.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AvailableAbsence = new HashSet<AvailableAbsence>();
            Contract = new HashSet<Contract>();
            InverseIdManagerNavigation = new HashSet<Employee>();
            Overtime = new HashSet<Overtime>();
            Request = new HashSet<Request>();
        }

        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string IdCardNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdJob { get; set; }
        public int? IdManager { get; set; }
        public bool IsActive { get; set; }
        public int IdRole { get; set; }

        public virtual Job IdJobNavigation { get; set; }
        public virtual Employee IdManagerNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<AvailableAbsence> AvailableAbsence { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Employee> InverseIdManagerNavigation { get; set; }
        public virtual ICollection<Overtime> Overtime { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
