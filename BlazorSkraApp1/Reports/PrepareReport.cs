using System.Collections.Generic;
using System.IO;
using BlazorSkraApp1.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BlazorSkraApp1.Services;
using BlazorSkraApp1.Models.InputModels;

namespace BlazorSkraApp1.Reports
{
    public class PrepareReport
    {
        #region Declaration
        int _maxColumn = 2;
        Document _document;
        PdfPTable _pdfTable = new PdfPTable(2);
        PdfPCell _pdfPCell;
        Font _fontStyle;
        MemoryStream _memoryStream = new MemoryStream();
        List<Report> _iReports = new List<Report>();
        #endregion

        public byte[] PDFReport(List<Report> iReports)
        {
            _iReports = iReports;

            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();

            float[] sizes = new float[_maxColumn];
            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0)
                {
                    sizes[i] = 50;
                }
                else
                {
                    sizes[i] = 100;
                }
            }
                _pdfTable.SetWidths(sizes);

                this.ReportHeader();
                this.ReportBody();

                _pdfTable.HeaderRows = 2;
                _document.Add(_pdfTable);
                _document.Close();

                return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase(_iReports[0].FormName, _fontStyle));
            _pdfPCell.Colspan = _maxColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(_iReports[0].UserName, _fontStyle));
            _pdfPCell.Colspan = _maxColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }

        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            var fontstyle = FontFactory.GetFont("Tahoma", 9f, 0);

            #region Table Header
            _pdfPCell = new PdfPCell(new Phrase("Spurning", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Svar", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();
            #endregion

            #region Table Body
            foreach(var iReport in _iReports)
            {

                _pdfPCell = new PdfPCell(new Phrase(iReport.Question, fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(iReport.Answer, fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();
            }
            #endregion
        }
    }
}