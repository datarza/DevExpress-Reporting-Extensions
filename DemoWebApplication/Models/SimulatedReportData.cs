using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApplication.Models
{
    public partial class SimulatedReportData
    {
        public IList<Person> Persons { get; set; }

        public static SimulatedReportData GetData(DateTime? dateFrom, DateTime? dateTo)
        {
            var date = new DateTime(DateTime.Today.Year - 1, 1, 1);

            return new SimulatedReportData
            {
                Persons = new List<Person>()
                {
                    new Person
                    {
                      ID = 1,
                      Number = "OW-2134",
                      FirstName = "Paul",
                      LastName = "Daker",
                      Type = "Electric",
                      Department = "Support",
                      Manager = "Mia Coty",
                      EmploymentDate = date.AddMonths(6).AddDays(3),
                      DismissalDate = date.AddMonths(10).AddDays(11),
                      Salary = 1234,
                    },
                    new Person
                    {
                      ID = 2,
                      Number = "OW-2137",
                      FirstName = "Devon",
                      LastName = "Curokasu",
                      Type = "Secretary",
                      Department = "Reception",
                      Manager = "Mia Coty",
                      EmploymentDate = date.AddMonths(5).AddDays(7),
                      DismissalDate = date.AddMonths(8).AddDays(17),
                      Salary = 4321,
                    },
                    new Person
                    {
                      ID = 3,
                      Number = "OW-2041",
                      FirstName = "Claris",
                      LastName = "Manole",
                      Type = "Secretary",
                      Department = "Reception",
                      Manager = "Mia Coty",
                      EmploymentDate = date.AddMonths(2).AddDays(8),
                      DismissalDate = null,
                      Salary = 5445,
                    },
                    new Person
                    {
                      ID = 4,
                      Number = "OW-3261",
                      FirstName = "Mia",
                      LastName = "Coty",
                      Type = "Manager",
                      Department = "Reception",
                      Manager = null,
                      EmploymentDate = date.AddMonths(1).AddDays(8),
                      DismissalDate = null,
                      Salary = 1234,
                    }
                }
                .Where(c => dateFrom.HasValue && c.EmploymentDate >= dateFrom && dateTo.HasValue && c.EmploymentDate <= dateTo ||
                            dateFrom.HasValue && c.EmploymentDate >= dateFrom && !dateTo.HasValue ||
                            !dateFrom.HasValue && dateTo.HasValue && c.EmploymentDate <= dateTo ||
                            !dateFrom.HasValue && !dateTo.HasValue)
                .ToList()
            };
        }
    }
}