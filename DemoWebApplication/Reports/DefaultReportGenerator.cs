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
            var band = new DetailBand()
            {
                HeightF = 0F
            };
            this.Bands.Add(band);

            var label = new XRLabel();
            label.DataBindings.Add(new XRBinding(nameof(label.Text), null, "ddd"));
            band.Controls.Add(label);
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
                new { ddd = 333 },
                new { ddd = 44 },
                new { ddd = 55 },
            };
        }

    }
}