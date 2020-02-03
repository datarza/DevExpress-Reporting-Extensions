using System.Collections.Generic;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;

namespace DevExpressReportingExtensions.Helpers
{
    public class CombinedGridHelper : BaseMasterDetailHelper
    {
        protected readonly DefaultPageHeaderHelper headerHelper;
        protected readonly DefaultGridHelper gridHelper;

        public PageBand HeaderBand { get { return this.headerHelper.ContainerBand; } }
        public DetailBand DetailBand { get { return this.gridHelper.ContainerBand; } }

        public IEnumerable<XRTableCell> HeaderColumns { get { return this.headerHelper.Columns; } }
        public IEnumerable<XRTableCell> DetailColumns { get { return this.gridHelper.Columns; } }
        
        public CombinedGridHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.headerHelper = new DefaultPageHeaderHelper(report);
            this.gridHelper = new DefaultGridHelper(report, detailReport);
        }

        public CombinedGridHelper AddColumn(
            double weight,
            string text,
            string dataMember,
            string formatString,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumn(weight, text, border, alignment);

            this.gridHelper.AddColumn(weight,  dataMember, formatString, border, alignment);

            return this;
        }

        public CombinedGridHelper AddColumn(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, text, dataMember, null, border, alignment);
        }

        public CombinedGridHelper AddColumnDate(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnDate(weight, text, border, alignment);

            this.gridHelper.AddColumnDate(weight, dataMember, border, alignment);

            return this;
        }

        public CombinedGridHelper AddColumnDateTime(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnDateTime(weight, text, border, alignment);

            this.gridHelper.AddColumnDateTime(weight, dataMember, border, alignment);

            return this;
        }
        
        public CombinedGridHelper AddColumnNumber(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnNumber(weight, text, border, alignment);

            this.gridHelper.AddColumnNumber(weight, dataMember, border, alignment);

            return this;
        }

        public CombinedGridHelper AddColumnMoney(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnMoney(weight, text, border, alignment);

            this.gridHelper.AddColumnMoney(weight, dataMember, border, alignment);

            return this;
        }

        public CombinedGridHelper AddColumnPercent(
            double weight,
            string text,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            this.headerHelper.AddColumnPercent(weight, text, border, alignment);

            this.gridHelper.AddColumnPercent(weight, dataMember, border, alignment);

            return this;
        }

        public CombinedGridHelper SetFormat(string formatString)
        {
            this.gridHelper.SetFormat(formatString);

            return this;
        }

        public CombinedGridHelper SetBorder(BorderSide border)
        {
            this.headerHelper.SetBorder(border);

            this.gridHelper.SetBorder(border);

            return this;
        }

        public CombinedGridHelper SetHeaderAlignment(TextAlignment alignment)
        {
            this.headerHelper.SetAlignment(alignment);

            return this;
        }

        public CombinedGridHelper SetAlignment(TextAlignment alignment)
        {
            this.headerHelper.SetAlignment(alignment);

            this.gridHelper.SetAlignment(alignment);

            return this;
        }

    }
}
