using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class XRTableRowExtensions
    {
        internal static XRTableCell AddCell(this XRTableRow row,
            double weight,
            string text)
        {
            var newCell = new XRTableCell
            {
                Text = text,
                Weight = weight
            };

            row.Cells.Add(newCell);

            return newCell;
        }

        internal static XRTableCell AddCell(this XRTableRow row,
            double weight)
        {
            return row.AddCell(weight, string.Empty);
        }

        internal static XRTableCell GetLastCell(this XRTableRow row)
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
