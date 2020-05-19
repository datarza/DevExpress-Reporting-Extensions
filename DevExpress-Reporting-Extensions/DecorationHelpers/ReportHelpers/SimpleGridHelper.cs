using System.Collections.Generic;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class SimpleGridHelper : BaseMasterDetailReportHelper
    {
        protected readonly SimpleGridHeaderHelper headerHelper;
        protected readonly SimpleGridColumnHelper columnHelper;

        public Band HeaderBand { get { return this.headerHelper.ContainerBand; } }
        public Band ColumnBand { get { return this.columnHelper.ContainerBand; } }

        public IEnumerable<XRTableCell> Headers { get { return this.headerHelper.Columns; } }
        public IEnumerable<XRTableCell> Columns { get { return this.columnHelper.Columns; } }

        public SimpleGridHelper(XtraReport report)
            : base(report)
        {
            this.headerHelper = this.RootReport.AddPageHeaderBand().AddGridHeaders();
            this.columnHelper = this.Report.AddDetailBand().AddGridColumns();
        }

        public SimpleGridHelper(XtraReport report, Band headersBand)
            : base(report)
        {
            this.headerHelper = headersBand.AddGridHeaders();
            this.columnHelper = this.Report.AddDetailBand().AddGridColumns();
        }

        public SimpleGridHelper(XtraReport report, XtraReportBase detailReport)
            : base(report, detailReport)
        {
            this.headerHelper = this.RootReport.AddPageHeaderBand().AddGridHeaders();
            this.columnHelper = this.Report.AddDetailBand().AddGridColumns();
        }

        public SimpleGridHelper(XtraReport report, XtraReportBase detailReport, Band headersBand)
            : base(report, detailReport)
        {
            this.headerHelper = headersBand.AddGridHeaders();
            this.columnHelper = this.Report.AddDetailBand().AddGridColumns();
        }

        public SimpleGridHelper AddColumn(
            double weight,
            string text,
            string dataMember,
            string formatString,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumn(weight, text, border, alignment);

            this.columnHelper.AddColumn(weight,  dataMember, formatString, border, alignment);

            return this;
        }

        public SimpleGridHelper AddColumn(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, text, dataMember, null, border, alignment);
        }

        public SimpleGridHelper AddColumnDate(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnDate(weight, text, border, alignment);

            this.columnHelper.AddColumnDate(weight, dataMember, border, alignment);

            return this;
        }

        public SimpleGridHelper AddColumnDateTime(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnDateTime(weight, text, border, alignment);

            this.columnHelper.AddColumnDateTime(weight, dataMember, border, alignment);

            return this;
        }


        public SimpleGridHelper AddColumnNumber(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnNumber(weight, text, border, alignment);

            this.columnHelper.AddColumnNumber(weight, dataMember, border, alignment);

            return this;
        }

        public SimpleGridHelper AddColumnMoney(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnMoney(weight, text, border, alignment);

            this.columnHelper.AddColumnMoney(weight, dataMember, border, alignment);

            return this;
        }

        public SimpleGridHelper AddColumnPercent(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnPercent(weight, text, border, alignment);

            this.columnHelper.AddColumnPercent(weight, dataMember, border, alignment);

            return this;
        }

        public SimpleGridHelper SetFormat(string formatString)
        {
            this.columnHelper.SetFormat(formatString);

            return this;
        }

        public SimpleGridHelper SetBorder(BorderSide border)
        {
            this.headerHelper.SetBorder(border);

            this.columnHelper.SetBorder(border);

            return this;
        }

        public SimpleGridHelper SetHeaderAlignment(TextAlignment alignment)
        {
            this.headerHelper.SetAlignment(alignment);

            return this;
        }

        public SimpleGridHelper SetAlignment(TextAlignment alignment)
        {
            this.headerHelper.SetAlignment(alignment);

            this.columnHelper.SetAlignment(alignment);

            return this;
        }

    }
}
