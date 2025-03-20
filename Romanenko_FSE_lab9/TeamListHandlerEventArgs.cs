using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeInfo { get; set; }
        public int ItemIndex { get; set; }

        public TeamListHandlerEventArgs(string collectionName, string changeInfo, int itemIndex)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            ItemIndex = itemIndex;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Info: {ChangeInfo}, Item Index: {ItemIndex}";
        }
    }
}
