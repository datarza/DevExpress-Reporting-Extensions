using System;
using System.Collections.Generic;

using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using myClippit.DevExpress.Report.Extensions;

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
                .SetCalendarWithTime(DateTime.Today.AddMonths(-6).AddTicks(1));

            this.dateToParam = this.CreateParameter("To")
                .SetCalendarWithTime(DateTime.Today.AddDays(1).AddTicks(-1));

        }

        private void InitializeDecorations()
        {
            this.AddReportHeader();

            this.AddCombinedGrid()
                .AddColumn(2.5D, "Name", "name");

            this.AddPageNumber();
        }

        protected override void OnDataSourceDemanded(EventArgs e)
        {
            base.OnDataSourceDemanded(e);

            this.DataSource = this.GetData(
                this.dateFromParam.GetValue<DateTime>(),
                this.dateToParam.GetValue<DateTime>());
        }

        protected IEnumerable<object> GetData(DateTime fromDate, DateTime toDate)
        {
            return new List<object>
            {
                new { name = 333 },
                new { name = 44 },
                new { name = 55 },
            };
        }

    }
}