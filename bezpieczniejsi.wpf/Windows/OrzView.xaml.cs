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
    /// Interaction logic for OrzView.xaml
    /// </summary>
    public partial class OrzView : Window
    {
        public IRiskAssessment ValueToRead;
        public OrzView()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAsPdfButton_Click(object sender, RoutedEventArgs e)
        {
            SaveAsPdf();
        }

        protected virtual void SaveAsPdf()
        {
           
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        protected virtual void ClearData()
        {
            
        }

        private void DescTextBox_OutputChanged(object sender, PiatToolkitWPF.StringChangedEventArgs args)
        {
            var control = sender as Control;
            if (control != null && control.Name == "CompN")
                ValueToRead.Header.CompanyName = args.NewValue;
            if (control != null && control.Name == "WorkN")
                ValueToRead.Header.JobName = args.NewValue;
        }

        private void DescButton_Click(object sender, RoutedEventArgs e)
        {
            RTFStringEditor editor = new RTFStringEditor(ValueToRead.JobDescription);
            editor.Owner = this;
            editor.Title = $"{ValueToRead.Header.CompanyName} : {ValueToRead.Header.JobName}";
            editor.ShowDialog();
            ValueToRead.JobDescription = editor.EditedString;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadHeaders();
        }

        protected void LoadHeaders()
        {
            CompN.Output = ValueToRead.Header.CompanyName;
            WorkN.Output = ValueToRead.Header.JobName;
        }
    }
}
