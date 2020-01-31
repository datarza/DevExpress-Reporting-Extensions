using System;

using DemoWebApplication.Models;

using myClippit.DevExpress.Report.Extensions;

namespace DemoWebApplication.Reports
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class GroupsReportGenerator : DevExpress.XtraReports.UI.XtraReport
    {
        public GroupsReportGenerator()
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
            this.AddReportHeader("Groups and Summaries example");

            this.AddCombinedGrid()
                .AddColumn(1D, "Number", nameof(Person.Number))
                .AddColumn(1.5D, "First Name", nameof(Person.FirstName))
                .AddColumn(1.5D, "Last Name", nameof(Person.LastName))
                .AddColumn(1.5D, "Type", nameof(Person.Type))
                .AddColumn(2.5D, "Manager", nameof(Person.Manager))
                .AddColumnDate(1D, "Started", nameof(Person.EmploymentDate))
                .AddColumnDate(1D, "Finished", nameof(Person.DismissalDate))
                .AddColumnMoney(1.5D, "Salary", nameof(Person.Salary));

            this.AddGroupHeader(nameof(Person.Department), "{0} Department").AdjustBorderStyleFromDetail();

            this.AddGroupFooter().AdjustBorderStyleFromDetail()
                .AddColumnCount(9.0D, nameof(Person.Number))
                .AddColumnMoney(1.5D, nameof(Person.Salary));

            this.AddPageNumber();
        }

        // bind data 
        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            this.DataSource = SimulatedReportData.GetData(null, null);
        }

    }
}