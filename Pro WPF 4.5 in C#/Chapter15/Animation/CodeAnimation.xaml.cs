using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Animation
{
    /// <summary>
    /// Interaction logic for SimpleAnimation.xaml
    /// </summary>

    public partial class CodeAnimation : System.Windows.Window
    {

        public CodeAnimation()
        {
            InitializeComponent();
        }


        private void cmdGrow_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.To = this.Width - 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            widthAnimation.Completed += animation_Completed;

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.To = (this.Height - 50)/3;
            heightAnimation.Duration = TimeSpan.FromSeconds(5);

            cmdGrow.BeginAnimation(Button.WidthProperty, widthAnimation);
            cmdGrow.BeginAnimation(Button.HeightProperty, heightAnimation);    
        }
        private void animation_Completed(object sender, EventArgs e)
        {
            //double currentWidth = cmdGrow.Width;
            //cmdGrow.BeginAnimation(Button.WidthProperty, null);
            //cmdGrow.Width = currentWidth;

            //MessageBox.Show("Completed!");
        }

        private void cmdShrink_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.Duration = TimeSpan.FromSeconds(5);            
            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.Duration = TimeSpan.FromSeconds(5);
            
            cmdGrow.BeginAnimation(Button.WidthProperty, widthAnimation);
            cmdGrow.BeginAnimation(Button.HeightProperty, heightAnimation);
        }

        private void cmdGrowIncrementally_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.By = 10;
            widthAnimation.Duration = TimeSpan.FromSeconds(0.5);                       

            cmdGrowIncrementally.BeginAnimation(Button.WidthProperty, widthAnimation);            
        }
    }
}