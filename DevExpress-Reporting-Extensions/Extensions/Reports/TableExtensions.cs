using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class TableExtensions
    {
        public static XRTableRow AddRow(this XRTable table, double weight)
        {
            var newRow = new XRTableRow
            {
                Weight = weight,
            };

            table.Rows.Add(newRow);

            return newRow;
        }

        public static XRTableRow AddRow(this XRTable table)
        {
            return table.AddRow(1D);
        }

        public static XRTableCell AddCell(this XRTableRow row, double weight, string text)
        {
            var newCell = new XRTableCell
            {
                Text = text,
                Weight = weight,
            };

            row.Cells.Add(newCell);

            return newCell;
        }

        public static XRTableCell AddCell(this XRTableRow row, double weight)
        {
            return row.AddCell(weight, string.Empty);
        }

        public static XRTableCell AddCell(this XRTableRow row)
        {
            return row.AddCell(1D, string.Empty);
        }

        public static XRTableCell GetLastCell(this XRTableRow row)
        {
            var cells = row.Cells;
            if (cells.Count > 0)
            {
                return cells[cells.Count - 1];
            }
            else
            {
                return null;
            }
        }

    }
}
