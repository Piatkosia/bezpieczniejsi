using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace bezpieczniejsi
{
    class RiskPdfGenerator
    {
        public bool SaveAsPdf<T>(RiskAssessment<T> Ra, string path) where T : RiskAssessmentRowModel, new()
        {
            Document pdfDoc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));

            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Ocena ryzyka zawodowego dla stanowiska " + Ra.Header.JobName + " w zakładzie " + Ra.Header.CompanyName)); //na razie - w dalszej kolejności umiędzynarodowić i zmienić na buildera

            PdfPTable table = new PdfPTable(Ra.PropNum);
            foreach (var item in Ra[0].Headers)
            {
                table.AddCell(item);
            }
            //Tu dodać potem ładny header
            foreach (T item in Ra)
            {
                foreach (string parameter in item.GetPrintableParameters())
                {
                    table.AddCell(parameter);
                }
            }
            pdfDoc.Add(table);
            pdfDoc.Add(new Paragraph("Przygotował/a: "));
            pdfDoc.Add(new Paragraph("Zatwierdził/a: "));
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
            cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
            cb.Stroke();

            pdfDoc.Close();
            return false;
        }
    }
}
