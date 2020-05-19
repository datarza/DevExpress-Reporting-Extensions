using System.Linq;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static PageHeaderBand AddPageHeaderBand(this XtraReport report)
        {
            var result = report.GetBandByType<PageHeaderBand>();
            if (result == null)
            {
                result = new PageHeaderBand()
                {
                    HeightF = 0F,
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static PageFooterBand AddPageFooterBand(this XtraReport report)
        {
            var result = report.GetBandByType<PageFooterBand>();
            if (result == null)
            {
                result = new PageFooterBand()
                {
                    HeightF = 0F,
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static ReportHeaderBand AddReportHeaderBand(this XtraReportBase report)
        {
            var result = report.GetBandByType<ReportHeaderBand>();
            if (result == null)
            {
                result = new ReportHeaderBand()
                {
                    HeightF = 0F,
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static ReportFooterBand AddReportFooterBand(this XtraReportBase report)
        {
            var result = report.GetBandByType<ReportFooterBand>();
            if (result == null)
            {
                result = new ReportFooterBand()
                {
                    HeightF = 0F,
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static GroupHeaderBand AddGroupHeaderBand(this XtraReportBase report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            var result = new GroupHeaderBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupUnion.WithFirstDetail,
                RepeatEveryPage = true,
                Level = report.Bands.OfType<GroupHeaderBand>().Count(),
            };
            result.GroupFields.Add(new GroupField(fieldName, sortOrder));
            report.Bands.Add(result);
            return result;
        }

        public static GroupHeaderBand AddGroupHeaderBand(this XtraReportBase report, params GroupField[] fields)
        {
            var result = new GroupHeaderBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupUnion.WithFirstDetail,
                RepeatEveryPage = true,
                Level = report.Bands.OfType<GroupHeaderBand>().Count(),
            };
            if (fields != null && fields.Length > 0)
            {
                result.GroupFields.AddRange(fields);
            }
            report.Bands.Add(result);
            return result;
        }

        public static GroupFooterBand AddGroupFooterBand(this XtraReportBase report)
        {
            var result = new GroupFooterBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupFooterUnion.WithLastDetail,
                RepeatEveryPage = false,
                Level = report.Bands.OfType<GroupFooterBand>().Count(),
            };
            report.Bands.Add(result);
            return result;
        }

        public static DetailBand AddDetailBand(this XtraReportBase report)
        {
            var result = report.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F,
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static TopMarginBand AddTopMarginBand(this XtraReport report)
        {
            var result = report.GetBandByType<TopMarginBand>();
            if (result == null)
            {
                result = new TopMarginBand
                {
                    HeightF = report.Margins.Top
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static BottomMarginBand AddBottomMarginBand(this XtraReport report)
        {
            var result = report.GetBandByType<BottomMarginBand>();
            if (result == null)
            {
                result = new BottomMarginBand
                {
                    HeightF = report.Margins.Bottom
                };
                report.Bands.Add(result);
            }
            return result;
        }

        public static SubBand AddSubBand(this Band band)
        {
            var result = new SubBand()
            {
                HeightF = 0F,
            };
            band.SubBands.Add(result);
            return result;
        }

    }
}