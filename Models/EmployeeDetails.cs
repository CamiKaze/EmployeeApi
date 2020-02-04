using System;

namespace Employees.API.Models
{
    public class EmployeeDetail
    {
        public long id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime employmentStartDate { get; set; }
        public DateTime employmentEndDate { get; set; }
    }
}