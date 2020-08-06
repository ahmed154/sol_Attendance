using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;
using System.IO;
using System.Data;
using pro_Models.ViewModels;

namespace pro_Server.Services
{
    public class PdfGenerate
    {
        public async Task<MemoryStream> CreatePDF(List<AttendanceReportViewModel> list)
        {
            if (list == null || list.Count == 0) throw new ArgumentNullException("No data found");

            using (PdfDocument doc = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                PdfPage page = doc.Pages.Add();
                PdfStandardFont standardFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement title = new PdfTextElement("Attendance Report", standardFont, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new Syncfusion.Drawing.PointF(0, 0));
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

                //Assign data source
                pdfGrid.DataSource = list;
                pdfGrid.Style.Font = contentFont;

                //Draw grid to the page of PDF document
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Save the document.
                using (MemoryStream stream = new MemoryStream())
                {
                    doc.Save(stream);
                    doc.Close(true);
                    return stream;
                };
            }
        }
    }
}
