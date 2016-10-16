using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using System.Windows.Controls;

namespace NavigationApplication
{
    public delegate void ReplayListChange(ListSelectionJournalEntry state);

    [Serializable()]
    public class ListSelectionJournalEntry : CustomContentState
    {
        private List<String> sourceItems;
        public List<String> SourceItems
        {
            get { return sourceItems; }
        }

        private List<String> targetItems;
        public List<String> TargetItems
        {
            get { return targetItems; }
        }
        private string journalName;
        private ReplayListChange replayListChange;
     
        public ListSelectionJournalEntry(
            List<String> sourceItems, List<String> targetItems, 
            string journalName, ReplayListChange replayListChange)
        {
            this.sourceItems = sourceItems;
            this.targetItems = targetItems;
            this.journalName = journalName;
            this.replayListChange = replayListChange;
        }

        // Need to override this property, if you want a CustomJournalEntry to appear in your back/forward stack
        public override string JournalEntryName
        {
            get
            {
                return journalName;
            }
        }

        // MANDATORY:  Need to override this method to restore the required state.
        // Since the "navigation" is not user-initiated ie. set by the user selecting 
        // a new ListBoxItem, we set the flag to false.
        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {  
            this.replayListChange(this);
        }
        
    }
}
