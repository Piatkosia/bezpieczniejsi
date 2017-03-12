using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    public partial class DescTextBox : UserControl
    {
       
        public DescTextBox()
        {
            InitializeComponent();
        }



        public string Input
        {
            get { return (string)GetValue(InputProperty); }
            set
            {
                SetValue(InputProperty, value);
                InputBox.Text = value;
            }
        }

        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register("Input", typeof(string), typeof(DescTextBox), new PropertyMetadata(string.Empty, InputValueChanged));

        private static void InputValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DescTextBox;
            if (control == null) return;
            control.InputBox.Text = e.NewValue.ToString();
        }
        public delegate void OutputEventHandler(object sender, StringChangedEventArgs args);
        StringChangedEventArgs args = new StringChangedEventArgs();
        public event OutputEventHandler OutputChanged;
        string _previousText = string.Empty;
        private void OutputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            args.NewValue = OutputBox.Text;
            args.OldValue = _previousText;
            OutputChanged?.Invoke(this, args);
        }

        private void OutputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _previousText = OutputBox.Text;
        }
    }
}
