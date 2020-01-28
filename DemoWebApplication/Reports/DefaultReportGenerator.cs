using System;
using System.Collections.Generic;

using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using myClippit.DevExpress.Report.Extensions;
using DevExpress.XtraPrinting;
using DemoWebApplication.Models;

namespace DemoWebApplication.Reports
{
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
            this.dateFromParam = this.CreateParameter("From")
                .SetCalendarWithTime(new DateTime(2000, 01, 01));

            this.dateToParam = this.CreateParameter("To")
                .SetCalendarWithTime(DateTime.Today);
        }

        // define decorations
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

        // select data based on parameters
        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            this.DataSource = SimulatedReportData.GetData(
                this.dateFromParam.GetValue<DateTime>(),
                this.dateToParam.GetValue<DateTime>());
        }

    }
}