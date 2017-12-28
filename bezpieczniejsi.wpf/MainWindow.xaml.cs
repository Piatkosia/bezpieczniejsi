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
using Microsoft.Win32;

namespace bezpieczniejsi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RiskBank list = new RiskBank();
        private LoadingProvider loader;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SomeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loader = new TextfileLoader();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true) list = loader.loadRisks(openFileDialog.FileName);
            //SomeList.ItemsSource = list.risks;
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ORZ_3s_click(object sender, RoutedEventArgs e)
        {
            var wnd = new ThreeGrade(new RiskAssessment<ThreeGradeRiskRowAssessmentModel>());
            wnd.Owner = this;
            wnd.Show(); //na razie niech się sobie powtarza
        }

        private void ORZ_5s_click(object sender, RoutedEventArgs e)
        {
            var wnd = new FiveGrade(new RiskAssessment<FiveGradeRiskRowAssessmentModel>());
            wnd.Owner = this;
            wnd.Show(); //na razie niech się sobie powtarza
        }
    }
}
