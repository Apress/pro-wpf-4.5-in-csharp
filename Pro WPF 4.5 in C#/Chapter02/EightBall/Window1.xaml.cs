using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

namespace EightBall
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void cmdAnswer_Click(object sender, RoutedEventArgs e)
        {           
            // Dramatic delay...
            this.Cursor = Cursors.Wait;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            AnswerGenerator generator = new AnswerGenerator();
            txtAnswer.Text = generator.GetRandomAnswer(txtQuestion.Text);
            this.Cursor = null;
        }

    }
}