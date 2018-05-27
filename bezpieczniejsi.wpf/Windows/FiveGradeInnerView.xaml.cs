using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bezpieczniejsi
{
    /// <summary>
    /// Interaction logic for FiveGradeInnerView.xaml
    /// </summary>
    public partial class FiveGradeInnerView : UserControl
    {
        private RiskAssessment<FiveGradeRiskRowAssessmentModel> riskAssessment;

        public IRiskAssessment ValueToRead { get { return riskAssessment; } }
        public FiveGradeInnerView()
        {
            InitializeComponent();
        }
        public FiveGradeInnerView(RiskAssessment<FiveGradeRiskRowAssessmentModel> riskAssessment)
        {
            this.riskAssessment = riskAssessment;
            InitializeComponent();
            AssignSource();
        }

        private void AssignSource()
        {
            this.DataContext = riskAssessment;
            dataGrid.ItemsSource = riskAssessment;
        }

        internal void ClearData()
        {
            riskAssessment = new RiskAssessment<FiveGradeRiskRowAssessmentModel>();
            AssignSource();
        }
    }
}
