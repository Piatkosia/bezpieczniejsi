using System;
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



        public string Output
        {
            get { return (string)GetValue(OutputProperty); }
            set { SetValue(OutputProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Output.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutputProperty =
            DependencyProperty.Register("Output", typeof(string), typeof(DescTextBox), new PropertyMetadata(string.Empty, OutputValueChanged));

        private static void OutputValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e == null) return;
            if (e.NewValue == null) return;
            var control = d as DescTextBox;
            if (control == null) return;
            control.OutputBox.Text = e.NewValue.ToString();
        }

        private static void InputValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e == null) return;
            if (e.NewValue == null) return;
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
