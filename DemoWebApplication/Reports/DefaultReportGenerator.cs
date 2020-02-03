using System;

using DemoWebApplication.Models;

using DevExpressReportingExtensions.Reports;
using DevExpressReportingExtensions.Helpers;

namespace DemoWebApplication.Reports
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class DefaultReportGenerator : DevExpress.XtraReports.UI.XtraReport
    {
        public DefaultReportGenerator()
        {
            // initialize report structure
            this.InitializeStructure();
            this.InitializeDataMember(nameof(SimulatedReportData.Persons));

            // initialize decorations
            this.InitializeDecorations();

        }

        // define decorations
        private void InitializeDecorations()
        {
            this.AddReportHeader("Simple example");

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

        // bind data 
        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            this.DataSource = SimulatedReportData.GetData();
        }

    }
}