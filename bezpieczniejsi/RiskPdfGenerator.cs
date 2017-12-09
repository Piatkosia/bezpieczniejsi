using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace bezpieczniejsi
{
    class RiskPdfGenerator
    {
        public bool SaveAsPdf<T>(RiskAssessment<T> Ra, string path) where T : RiskAssessmentRowModel, new()
        {
            PdfPTable table = new PdfPTable(Ra.PropNum);

            foreach (T item in Ra)
            {
                item.GetPrintableParameters();
            }
            return false;
        }
    }
}
