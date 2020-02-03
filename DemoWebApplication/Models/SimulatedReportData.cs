using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bogus;

namespace DemoWebApplication.Models
{
    public partial class SimulatedReportData
    {
        public IList<Person> Persons { get; set; }

        public static SimulatedReportData GetData()
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
            };
        }

        public static SimulatedReportData GetBigData(DateTime? dateFrom, DateTime? dateTo,
            int number = 100)
        {
            int personIdIncrement = 1;
            var date = new DateTime(DateTime.Today.Year - 1, 1, 1);
            var faker = new Faker();

            return new SimulatedReportData
            {
                Persons = Enumerable.Range(0, number)
                    .Select(o => new Person
                    {
                        ID = personIdIncrement++,
                        Number = $"{faker.Address.StateAbbr()}-{faker.Random.AlphaNumeric(3).ToUpperInvariant()}",
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        Type = faker.Name.JobType(),
                        Department = faker.Commerce.Department(1),
                        Manager = faker.Name.FullName(),
                        EmploymentDate = faker.Date.Between(date, DateTime.Today),
                        DismissalDate = faker.Random.Bool(0.4f) ? faker.Date.Between(date, DateTime.Today) : new DateTime?(),
                        Salary = faker.Random.Decimal(1000, 10000),
                    })
                    .ToList()
                    .Select(c => 
                    {
                        if (c.DismissalDate.HasValue && c.EmploymentDate > c.DismissalDate)
                        {
                            var saveDate = c.EmploymentDate;
                            c.EmploymentDate = c.DismissalDate.Value;
                            c.DismissalDate = saveDate;
                        }
                        return c;
                    })
                    .Where(c => dateFrom.HasValue && c.EmploymentDate >= dateFrom && dateTo.HasValue && c.EmploymentDate <= dateTo ||
                            dateFrom.HasValue && c.EmploymentDate >= dateFrom && !dateTo.HasValue ||
                            !dateFrom.HasValue && dateTo.HasValue && c.EmploymentDate <= dateTo ||
                            !dateFrom.HasValue && !dateTo.HasValue)
                    .ToList()
            };
        }

    }
}