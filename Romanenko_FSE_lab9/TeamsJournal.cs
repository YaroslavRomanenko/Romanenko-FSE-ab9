using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class TeamsJournal
    {
        private List<TeamsJournalEntry> _entries = new List<TeamsJournalEntry>();

        public void OnTeamListChanged(object source, TeamListHandlerEventArgs args)
        {
            _entries.Add(new TeamsJournalEntry(args.CollectionName, args.ChangeInfo, args.ItemIndex));
        }

        public override string ToString()
        {
            if (_entries.Count == 0)
                return "Journal is empty.";

            string result = "Teams Journal Entries:\n";
            foreach (var entry in _entries)
            {
                result += entry.ToString() + "\n";
            }
            return result;
        }
    }
}
