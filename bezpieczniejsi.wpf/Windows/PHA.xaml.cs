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
using System.Windows.Shapes;

namespace bezpieczniejsi
{
    /// <summary>
    /// Interaction logic for PHA.xaml
    /// </summary>
    public partial class PHA : Window
    {
        private RiskAssessment<PHARiskRowAssessmentModel> riskAssessment;

        public PHA()
        {
            InitializeComponent();
        }

        public PHA(RiskAssessment<PHARiskRowAssessmentModel> riskAssessment)
        {
            this.riskAssessment = riskAssessment;
            InitializeComponent();
            this.DataContext = riskAssessment;
            dataGrid.ItemsSource = riskAssessment;
            Size.ItemsSource = PHARiskRowAssessmentModel.SizeDescription;
            Probability.ItemsSource = PHARiskRowAssessmentModel.ProbabilityDescription;
        }

        private void DescButton_Click(object sender, RoutedEventArgs e)
        {
            RTFStringEditor editor = new RTFStringEditor(riskAssessment.JobDescription);
            editor.Owner = this;
            editor.Title = $"{riskAssessment.Header.CompanyName} : {riskAssessment.Header.JobName}";
            editor.ShowDialog();
            riskAssessment.JobDescription = editor.EditedString;
        }

        private void DescTextBox_OutputChanged(object sender, PiatToolkitWPF.StringChangedEventArgs args)
        {
            var control = sender as Control;
            if (control != null && control.Name == "CompN")
                riskAssessment.Header.CompanyName = args.NewValue;
            if (control != null && control.Name == "WorkN")
                riskAssessment.Header.JobName = args.NewValue;
        }
        private void Window_Activated(object sender, System.EventArgs e)
        {
            LoadHeaders();
        }

        private void LoadHeaders()
        {
            CompN.Output = riskAssessment.Header.CompanyName;
            WorkN.Output = riskAssessment.Header.JobName;
        }
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("removed");
        }

        private void SaveAsPdfButton_Click(object sender, RoutedEventArgs e)
        {
            RiskPdfGenerator gen = new RiskPdfGenerator();
            if (gen.SaveAsPdf(riskAssessment)) MessageBox.Show("OK");
            else MessageBox.Show("Error");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            riskAssessment = new RiskAssessment<PHARiskRowAssessmentModel>();
            this.DataContext = riskAssessment;
            dataGrid.ItemsSource = riskAssessment;
        }
    }
}
