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
using System.Reflection;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MonitorCommands.xaml
    /// </summary>

    public partial class MonitorCommands : System.Windows.Window
    {
        private static RoutedUICommand applicationUndo;

        public static RoutedUICommand ApplicationUndo
        {
            get { return MonitorCommands.applicationUndo; }
        }

        static MonitorCommands()
        {
            applicationUndo = new RoutedUICommand(
              "ApplicationUndo", "Application Undo", typeof(MonitorCommands));
        }


        public MonitorCommands()
        {
            InitializeComponent();

            this.AddHandler(CommandManager.PreviewExecutedEvent,
               new ExecutedRoutedEventHandler(CommandExecuted)); 
        }

        private void window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.RemoveHandler(CommandManager.PreviewExecutedEvent,
               new ExecutedRoutedEventHandler(CommandExecuted));
        }
                
        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Ignore menu button source.
            if (e.Source is ICommandSource) return;

            // Ignore the ApplicationUndo command.
            if (e.Command == MonitorCommands.ApplicationUndo) return;

            // Could filter for commands you want to add to the stack
            // (for example, not selection events).

            TextBox txt = e.Source as TextBox;
            if (txt != null)
            {
                RoutedCommand cmd = (RoutedCommand)e.Command;
                
                CommandHistoryItem historyItem = new CommandHistoryItem(
                    cmd.Name, txt, "Text", txt.Text);

                ListBoxItem item = new ListBoxItem();
                item.Content = historyItem;
                lstHistory.Items.Add(historyItem);

               // CommandManager.InvalidateRequerySuggested();
            }
        }

        private void ApplicationUndoCommand_Executed(object sender, RoutedEventArgs e)
        {
            CommandHistoryItem historyItem = (CommandHistoryItem)lstHistory.Items[lstHistory.Items.Count - 1];
            if (historyItem.CanUndo) historyItem.Undo();
            lstHistory.Items.Remove(historyItem);
        }

        private void ApplicationUndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lstHistory == null || lstHistory.Items.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        
    }

    public class CommandHistoryItem
    {
        public string CommandName
        {
            get;
            set;
        }

        public UIElement ElementActedOn
        {
            get;
            set;
        }

        public string PropertyActedOn
        {
            get;
            set;
        }
                
        public object PreviousState
        {
            get;
            set;
        }

        public CommandHistoryItem(string commandName)
            : this(commandName, null, "", null)
        { }

        public CommandHistoryItem(string commandName, UIElement elementActedOn,
            string propertyActedOn, object previousState)
        {
            CommandName = commandName;
            ElementActedOn = elementActedOn;
            PropertyActedOn = propertyActedOn;
            PreviousState = previousState;
        }
        public bool CanUndo
        {
            get { return (ElementActedOn != null && PropertyActedOn != ""); }
        }

        public void Undo()
        {
            Type elementType = ElementActedOn.GetType();
            PropertyInfo property = elementType.GetProperty(PropertyActedOn);
            property.SetValue(ElementActedOn, PreviousState, null);
        }
    }

}