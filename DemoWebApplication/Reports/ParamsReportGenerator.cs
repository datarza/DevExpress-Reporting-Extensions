using System;

using DemoWebApplication.Models;

using DevExpress.XtraReports.Parameters;

using DevExpressReportingExtensions.Extensions;
using DevExpressReportingExtensions.DecorationHelpers;

namespace DemoWebApplication.Reports
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class ParamsReportGenerator : DevExpress.XtraReports.UI.XtraReport
    {
        public ParamsReportGenerator()
        {
            // initialize report structure
            this.InitializeStructure();
            this.InitializeDataMember(nameof(SimulatedReportData.Persons));

            // initialize report parameters
            this.InitializeParameters();

            // initialize decorations
            this.InitializeDecorations();
        }

        // define parameters
        private Parameter dateFromParam;
        private Parameter dateToParam;

        private void InitializeParameters()
        {
            this.dateFromParam = this.CreateParameter("From")
                .SetCalendarWithTime(new DateTime(DateTime.Today.Year - 1, 1, 1).AddMonths(3));

            this.dateToParam = this.CreateParameter("To")
                .SetCalendarWithTime(DateTime.Today);
        }

        // define decorations

        SimpleReportHeaderHelper headerHelper;

        private void InitializeDecorations()
        {
            this.headerHelper = this.AddReportHeader("Filtering the data", "Report example");

            this.AddGrid()
                .AddColumn(1D, "Number", nameof(Person.Number))
                .AddColumn(1.5D, "First Name", nameof(Person.FirstName))
                .AddColumn(1.5D, "Last Name", nameof(Person.LastName))
                .AddColumn(1.5D, "Type", nameof(Person.Type))
                .AddColumn(2.5D, "Manager", nameof(Person.Manager))
                .AddColumnDate(1D, "Started", nameof(Person.EmploymentDate))
                .AddColumnDate(1D, "Finished", nameof(Person.DismissalDate))
                .AddColumnMoney(1.5D, "Salary", nameof(Person.Salary));

            this.AddGroupHeader(nameof(Person.Department));

            this.AddGroupFooter()
                .AddColumnCount(9.0D, nameof(Person.Number))
                .AddColumnMoney(1.5D, nameof(Person.Salary));

            this.AddPageNumbers();
        }

        // bind data based on parameters
        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            // get parameter values
            var dateFrom = dateFromParam.GetValue<DateTime>();
            var dateTo = dateToParam.GetValue<DateTime>();

            this.headerHelper.PrintDatesInterval(dateFrom, dateTo);
            this.headerHelper.PrintCurrentTime(DateTime.Now);

            this.DataSource = SimulatedReportData.GetBigData(dateFrom, dateTo);
        }

    }
}