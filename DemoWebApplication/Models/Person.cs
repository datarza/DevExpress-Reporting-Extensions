using System;

namespace DemoWebApplication.Models
{
    public class Person
    {
        public int ID { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public string Department { get; set; }

        public string Manager { get; set; }

        public DateTime EmploymentDate { get; set; }

        public DateTime? DismissalDate { get; set; }

        public decimal? Salary { get; set; }
    }

}
