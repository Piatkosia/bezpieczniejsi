using System.Windows;
using System.Windows.Controls;

namespace PiatToolkitWPF
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
