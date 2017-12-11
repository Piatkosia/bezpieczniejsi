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
    /// Interaction logic for RTFStringEditor.xaml
    /// </summary>
    public partial class RTFStringEditor : Window
    {
        public RTFStringEditor()
        {
            InitializeComponent();
        }
        public string EditedString = "";
        public RTFStringEditor(string StringToEdit)
        {
            InitializeComponent();
            EditedString = StringToEdit;
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(StringToEdit)));
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            EditedString = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
