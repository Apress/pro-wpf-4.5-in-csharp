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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationApplication
{
    /// <summary>
    /// Interaction logic for PageWithMultipleJournalEntries.xaml
    /// </summary>

    public partial class PageWithMultipleJournalEntries : System.Windows.Controls.Page, IProvideCustomContentState 
    {
        public PageWithMultipleJournalEntries()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, EventArgs e)
        {
            lstSource.Items.Add("Red");
            lstSource.Items.Add("Blue");
            lstSource.Items.Add("Green");
            lstSource.Items.Add("Yellow");
            lstSource.Items.Add("Orange");
            lstSource.Items.Add("Black");
            lstSource.Items.Add("Pink");
            lstSource.Items.Add("Purple");
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstSource.SelectedIndex != -1)
            {
                // Determine the best name to use in the navigation history.
                NavigationService nav = NavigationService.GetNavigationService(this);
                string itemText = lstSource.SelectedItem.ToString();
                string journalName = "Added " + itemText;

                // Update the journal (using the method shown below.)        
                nav.AddBackEntry(GetJournalEntry(journalName));

                // Now perform the change.
                lstTarget.Items.Add(itemText);
                lstSource.Items.Remove(itemText);
            }

        }
        
        private bool isReplaying;
        private void Replay(ListSelectionJournalEntry state)
        {
            this.isReplaying = true;

            lstSource.Items.Clear();
            foreach (string item in state.SourceItems)
              { lstSource.Items.Add(item); }
            
            lstTarget.Items.Clear();
            foreach (string item in state.TargetItems)
            { lstTarget.Items.Add(item); }

            restoredStateName = state.JournalEntryName;
            this.isReplaying = false;
        }

        private string restoredStateName;

        private void cmdRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstTarget.SelectedIndex != -1)
            {              
                // Determine the best name to use in the navigation history.
                NavigationService nav = NavigationService.GetNavigationService(this);
                string itemText = lstTarget.SelectedItem.ToString();
                string journalName = "Removed " + itemText;

                // Update the journal (using the method shown below.)        
                nav.AddBackEntry(GetJournalEntry(journalName));
                
                // Perform the change.
                lstSource.Items.Add(itemText);
                lstTarget.Items.Remove(itemText);
            }
        }

        private ListSelectionJournalEntry GetJournalEntry(string journalName)
        {
            // Get the state of both lists (using a helper method).
            List<String> source = GetListState(lstSource);
            List<String> target = GetListState(lstTarget);

            // Create the custom state object with this information.
            // Point the callback to the Replay method in this class.
            return new ListSelectionJournalEntry(
              source, target, journalName, Replay);
        }


        public CustomContentState GetContentState()
        {
            string journalName;
            if (restoredStateName != "")
                journalName = restoredStateName;
            else
                journalName = "PageWithMultipleJournalEntries";

            return GetJournalEntry(journalName);
        }

        private List<String> GetListState(ListBox list)
        {
            List<string> items = new List<string>();
            foreach (string item in list.Items)
            {
                items.Add(item);
            }
            return items;
        }
    }
}