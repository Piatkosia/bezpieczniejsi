﻿using System;
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
    /// Interaction logic for ThreeGrade.xaml
    /// </summary>
    public partial class ThreeGrade : Window
    {
        public ThreeGrade()
        {
            InitializeComponent();
        }

        private void DescTextBox_OutputChanged(object sender, StringChangedEventArgs args)
        {
          //tu poustawiać wartości w odpowiednie miejsca jak już powstanie klasa
        }
    }
}