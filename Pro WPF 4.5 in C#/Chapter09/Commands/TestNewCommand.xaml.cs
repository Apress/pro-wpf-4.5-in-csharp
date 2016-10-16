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

namespace Commands
{
    /// <summary>
    /// Interaction logic for TestNewCommand.xaml
    /// </summary>

    public partial class TestNewCommand : System.Windows.Window
    {

        public TestNewCommand()
        {
            //ApplicationCommands.New.Text = "Completely New";

            InitializeComponent();
            
            //CommandBinding bindingNew = new CommandBinding(ApplicationCommands.New);
            //bindingNew.Executed += NewCommand;
            
            //this.CommandBindings.Add(bindingNew);
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {            
            MessageBox.Show("New command triggered by " + e.Source.ToString());
        }

        private void cmdDoCommand_Click(object sender, RoutedEventArgs e)
        {
            this.CommandBindings[0].Command.Execute(null);
           // ApplicationCommands.New.Execute(null, (Button)sender);
        }

    }
}