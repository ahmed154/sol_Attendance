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
using pro_Models.Models;
using System.Reflection;
using Syncfusion.Blazor.Grids;
using Newtonsoft.Json;

namespace pro_Server.Services
{
    public class PdfGenerate
    {
        public async Task<MemoryStream> CreatePDF(SfGrid<AttendanceReportViewModel> grid, AttReportSet attReportSet, ReportViewModel ReportVM)
        {       
            string json = JsonConvert.SerializeObject(grid.DataSource);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            int i = 0;
            if (!attReportSet.Date) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Day) dt.Columns.RemoveAt(i); else i++;

            if (!attReportSet.Attend1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.EarlyAttend1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Late1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Depart1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.EarlyDepart1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Bonus1) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Shift1) dt.Columns.RemoveAt(i); else i++;

            if (!attReportSet.Attend2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.EarlyAttend2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Late2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Depart2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.EarlyDepart2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Bonus2) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Shift2) dt.Columns.RemoveAt(i); else i++;

            if (!attReportSet.Early) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Late) dt.Columns.RemoveAt(i);
            if (!attReportSet.EarlyDepart) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Bonus) dt.Columns.RemoveAt(i); else i++;

            if (!attReportSet.TotalTime) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.TotalSubtract) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.TotalSupplement) dt.Columns.RemoveAt(i); else i++;

            if (!attReportSet.TotalHours) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Holiday) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Absent) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.AttendDevice) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.DepartDevice) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.Worksys) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.BonusType) dt.Columns.RemoveAt(i); else i++;
            if (!attReportSet.UpdatedActions) dt.Columns.RemoveAt(i); else i++;

            //for (int x = 0; x < dt.Columns.Count; x++)
            //{
            //    dt.Columns[x].ColumnName = grid.Columns[x].HeaderText;
            //}

            if (grid.DataSource == null) throw new ArgumentNullException("No data found");

            using (PdfDocument doc = new PdfDocument())
            {
                int paragraphAfterSpacing = 18;
                int cellMargin = 4;
                PdfStandardFont standardFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfStandardFont HeaderFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 8);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                PdfPage page = doc.Pages.Add();

                #region Header
                PdfTextElement title = new PdfTextElement("Attendance Report", standardFont, PdfBrushes.Black);
                PdfTextElement empName = new PdfTextElement("Employee Name : " + ReportVM.Employee.Name, HeaderFont, PdfBrushes.Black);
                PdfTextElement attSys = new PdfTextElement("Attendance System : " + ReportVM.Worksys.Name, HeaderFont, PdfBrushes.Black);
                PdfTextElement depart = new PdfTextElement("Department : " , HeaderFont, PdfBrushes.Black);
                PdfTextElement sec = new PdfTextElement("Section : " , HeaderFont, PdfBrushes.Black);
                PdfTextElement fromDate = new PdfTextElement("From : " + ReportVM.FromDate, HeaderFont, PdfBrushes.Black);
                PdfTextElement toDate = new PdfTextElement("To : " + ReportVM.ToDate, HeaderFont, PdfBrushes.Black);
                #endregion

                PdfLayoutResult result = title.Draw(page, new Syncfusion.Drawing.PointF(170, 0));
                result = empName.Draw(page, new Syncfusion.Drawing.PointF(0, 20));
                result = fromDate.Draw(page, new Syncfusion.Drawing.PointF(0, 40));
                result = toDate.Draw(page, new Syncfusion.Drawing.PointF(0, 60));

                result = attSys.Draw(page, new Syncfusion.Drawing.PointF(300, 20));
                result = depart.Draw(page, new Syncfusion.Drawing.PointF(300, 40));
                result = sec.Draw(page, new Syncfusion.Drawing.PointF(300, 60));



                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable1Light);

                //Assign data source
                pdfGrid.DataSource = dt;
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
