using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class TeamsJournalEntry
    {
        public string CollectionName { get; }
        public string ChangeInfo { get; }
        public int ItemIndex { get; }

        public TeamsJournalEntry(string collectionName, string changeInfo, int itemIndex)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            ItemIndex = itemIndex;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change: {ChangeInfo}, Index: {ItemIndex}";
        }
    }
}
