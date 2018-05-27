using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bezpieczniejsi.wpf.Windows
{
    class FiveGradeWindow : OrzView
    { 
        FiveGradeInnerView view;
        public FiveGradeWindow(RiskAssessment<FiveGradeRiskRowAssessmentModel> riskAssessment)
        {
            view = new FiveGradeInnerView(riskAssessment);
            ValueToRead = view.ValueToRead;
            MethodGrid.Children.Add(view);
        }

        protected override void SaveAsPdf()
        {
            RiskPdfGenerator gen = new RiskPdfGenerator();
            MessageBox.Show(gen.SaveAsPdf(ValueToRead as RiskAssessment<FiveGradeRiskRowAssessmentModel>)
                ? "OK"
                : "Error");
        }

        protected override void ClearData()
        {
            view.ClearData();
            LoadHeaders();
            
        }

    }
}
