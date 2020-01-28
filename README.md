These extensions make the creating DevExpress Reports easier and clear. Instead of using the Report Designer developer can do it directly in C# code:

```csharp
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
```

```csharp
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
                .Where(c => c.EmploymentDate >= dateFrom && c.EmploymentDate <= dateTo)
                .ToList()
            };
        }
    }
```

 ```csharp
    [System.ComponentModel.DesignerCategory("Code")]
    public class DefaultReportGenerator : DevExpress.XtraReports.UI.XtraReport
    {
        public DefaultReportGenerator()
        {
            this.BeginUpdate();

            // initialize report structure
            this.InitializeStructure(false);
            this.InitializeDataMember(nameof(SimulatedReportData.Persons));

            // initialize report parameters
            this.InitializeParameters();

            // initialize decorations
            this.InitializeDecorations();

            this.EndUpdate();
        }

        // define parameters
        private Parameter dateFromParam;
        private Parameter dateToParam;

        private void InitializeParameters()
        {
            // setup parameters
            this.dateFromParam = this.CreateParameter("From")
                .SetCalendarWithTime(new DateTime(2000, 01, 01));

            this.dateToParam = this.CreateParameter("To")
                .SetCalendarWithTime(DateTime.Today);
        }

        private void InitializeDecorations()
        {
            this.AddReportHeader();

            this.AddCombinedGrid()
                .AddColumn(1D, "Number", nameof(Person.Number))
                .AddColumn(1.5D, "First Name", nameof(Person.FirstName))
                .AddColumn(1.5D, "Last Name", nameof(Person.LastName))
                .AddColumn(1.5D, "Type", nameof(Person.Type))
                .AddColumn(1.5D, "Department", nameof(Person.Department))
                .AddColumn(2.5D, "Manager", nameof(Person.Manager))
                .AddColumnDate(1D, "Started", nameof(Person.EmploymentDate))
                .AddColumnDate(1D, "Finished", nameof(Person.DismissalDate))
                .AddColumnMoney(1.5D, "Salary", nameof(Person.Salary));

            this.AddPageNumber();
        }

        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            this.DataSource = SimulatedReportData.GetData(
                this.dateFromParam.GetValue<DateTime>(),
                this.dateToParam.GetValue<DateTime>());
        }

    }
```
