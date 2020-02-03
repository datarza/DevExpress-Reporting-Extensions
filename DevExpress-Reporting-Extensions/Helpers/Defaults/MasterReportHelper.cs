using System;
using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultMasterReportHelper : BaseDetailReportHelper
    {
        public readonly XRLabel HeaderLabel;

        public DefaultMasterReportHelper(XtraReport report, string dataMember)
            : base(report, dataMember)
        {
        }

        public DefaultMasterReportHelper(XtraReport report, string dataMember,
            string headerDataMember,
            string formatString = null)
            : base(report, dataMember)
        {
            this.HeaderLabel = this.CreateGroupHeader(headerDataMember, formatString);
        }

        protected virtual XRLabel CreateGroupHeader(string dataMember, string formatString = null)
        {
            var result = new XRLabel
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth(),
                       Convert.ToSingle(Math.Round(-(this.ContainerBand.Level * 2F) + 25F, 2))),
                Padding = new PaddingInfo(2, 0, 0, 0),
                ForeColor = this.ContainerBand.Level % 2 == 0 ? Color.Coral : Color.SteelBlue,
                Font = new Font(FontFamily.GenericSansSerif,
                       Convert.ToSingle(Math.Round(-(this.ContainerBand.Level / 50F) + 0.14F, 2)),
                           FontStyle.Bold, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.BottomLeft,
            };

            result.AddTextBinding(this.ContainerBand.JoinWithDataMember(dataMember), formatString);

            this.CreateDetailContainer(result);

            if (this.ContainerBand.Level == 0)
            {
                result.PrintOnPage += delegate (object sender, PrintOnPageEventArgs e)
                {
                    var label = (XRControl)sender;
                    label.Bookmark = label.Text;
                    if (label.Tag != null)
                    {
                        label.BookmarkParent = label.Tag as XRControl;
                    }
                };
            }

            return result;
        }

    }
}
