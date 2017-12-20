using System.Windows;
using PiatToolkitWPF;
using System.Windows.Controls;
using Microsoft.Win32;

namespace bezpieczniejsi
{
    /// <summary>
    /// Interaction logic for ThreeGrade.xaml
    /// </summary>
    public partial class ThreeGrade : Window
    {
        private ThreeGradeRa valueToRead;
        public ThreeGrade(ThreeGradeRa ra)
        {
            valueToRead = ra;
            InitializeComponent();
            this.DataContext = valueToRead;
            dataGrid.ItemsSource = valueToRead;

        }

        private void DescTextBox_OutputChanged(object sender, StringChangedEventArgs args)
        {
            var control = sender as Control;
            if (control != null && control.Name == "CompN")
                valueToRead.Header.CompanyName = args.NewValue;
            if (control != null && control.Name == "WorkN")
                valueToRead.Header.JobName = args.NewValue;

        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            LoadHeaders();
        }

        private void LoadHeaders()
        {
            CompN.Output = valueToRead.Header.CompanyName;
            WorkN.Output = valueToRead.Header.JobName;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pr = new PrintDialog();
            pr.ShowDialog();
            WpfPrinting printing = new WpfPrinting();
            printing.PrintDataGrid(null, dataGrid, null, pr); //potem dodam nagłówek i stopkę
        }

        private void DescButton_Click(object sender, RoutedEventArgs e)
        {
            RTFStringEditor editor = new RTFStringEditor(valueToRead.JobDescription);
            editor.Owner = this;
            editor.ShowDialog();
            editor.Title = valueToRead.Header.CompanyName + " : " + valueToRead.Header.JobName;
            valueToRead.JobDescription = editor.EditedString;
        }

        private void SaveAsPdfButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "PDF Files(*.pdf)|*.pdf|All(*.*)|*",

            };

            if (dialog.ShowDialog() == true)
            {
                RiskPdfGenerator gen = new RiskPdfGenerator();
                gen.SaveAsPdf(valueToRead, dialog.FileName);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            valueToRead = new ThreeGradeRa();
            this.DataContext = valueToRead;
        }
    }
}
