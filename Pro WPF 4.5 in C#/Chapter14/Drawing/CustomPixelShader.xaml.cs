﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Interaction logic for CustomPixelShader.xaml
    /// </summary>
    public partial class CustomPixelShader : Window
    {
        public CustomPixelShader()
        {
            InitializeComponent();
        }

        private void chkEffect_Click(object sender, RoutedEventArgs e)
        {
            if (chkEffect.IsChecked != true)
                img.Effect = null;
            else
                img.Effect = new GrayscaleEffect();
        }
    }
}
