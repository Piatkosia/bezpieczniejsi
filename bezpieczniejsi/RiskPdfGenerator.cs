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
            if (Ra == null || !string.IsNullOrEmpty(path)) return false;
            Document pdfDoc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
            if (writer == null) return false;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.EMBEDDED);
            Font normal = new Font(bf, 8f, Font.NORMAL, BaseColor.BLACK);
            Font normal_table = new Font(bf, 6f, Font.NORMAL, BaseColor.BLACK);
            pdfDoc.Open();
            if (Ra.Header != null && !String.IsNullOrWhiteSpace(Ra.Header.JobName) && !String.IsNullOrWhiteSpace(Ra.Header.CompanyName))
                pdfDoc.Add(new Paragraph(string.Format("Ocena ryzyka zawodowego dla stanowiska {0} w zakładzie {1}", Ra.Header.JobName, Ra.Header.CompanyName), normal)); //na razie - w dalszej kolejności umiędzynarodowić i zmienić na buildera
            if (!String.IsNullOrWhiteSpace(Ra.JobDescription))
            {
                pdfDoc.Add(new Paragraph("Opis stanowiska: ", normal));
                pdfDoc.Add(new Paragraph(Ra.JobDescription, normal));
            }
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(new Paragraph("Ocena ryzyka", normal));
            pdfDoc.Add(new Paragraph("", normal));
            pdfDoc.Add(Chunk.NEWLINE);
            if (Ra.Any())
            {
                PdfPTable table = new PdfPTable(Ra.PropNum);
                table.WidthPercentage = 100;

                table.HeaderRows = 1;
                foreach (var item in Ra[0].Headers)
                {
                    if (item == null) table.AddCell("  ");
                    else table.AddCell(new Paragraph(item, normal_table));
                }
                foreach (T item in Ra)
                {
                    foreach (string parameter in item.GetPrintableParameters())
                    {
                        string tmp = parameter;
                        if (parameter == null) tmp = "  ";
                        table.AddCell(new Paragraph(tmp, normal_table));
                    }
                }
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(table);
            }


            pdfDoc.Add(new Paragraph("Przygotował/a: ................................................", normal));
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(new Paragraph("Zatwierdził/a:  ................................................", normal));
            pdfDoc.Close();
            return true;
        }
    }
}
