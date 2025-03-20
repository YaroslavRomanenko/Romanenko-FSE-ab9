using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class ResearchTeamPublicationComparer : IComparer<ResearchTeam>
    {
        public static readonly ResearchTeamPublicationComparer Instance = new ResearchTeamPublicationComparer();

        private ResearchTeamPublicationComparer() { }
        public int Compare(ResearchTeam? left, ResearchTeam? right)
        {
            return left.PublicationList.Count - right.PublicationList.Count;
        }
    }
}
