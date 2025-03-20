using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class ResearchTeamCollection
    {
        private List<ResearchTeam> _researchTeams;
        public string CollectionName { get; }

        public ResearchTeamCollection(string collectionName)
        {
            CollectionName = collectionName;
            _researchTeams = new List<ResearchTeam>();
        }

        public void AddDefaults()
        {
            _researchTeams.Add(new ResearchTeam());
            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(
                CollectionName,
                "Research team added",
                _researchTeams.Count - 1
            ));
        }

        public void AddResearchTeams(ResearchTeam[] researchTeams)
        {
            if (researchTeams == null)
                throw new ArgumentNullException("researchTeam is null");

            foreach (var researchTeam in researchTeams)
            {
                _researchTeams.Add(researchTeam);
                ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(
                    CollectionName,
                    "Research team added",
                    _researchTeams.Count - 1
                ));
            }
        }

        public void SortByTheRegistrationID()
        {
            _researchTeams.Sort();
        }

        public void SortByResearchTopic()
        {
            _researchTeams.Sort(new ResearchTeam());
        }

        public void SortByPublicationCount()
        {
            _researchTeams.Sort(ResearchTeamPublicationComparer.Instance);
        }
        public int MinRegistrationID
        {
            get
            {
                return _researchTeams.Select(team => team.RegistrationID).Min();
            }
        }

        public IEnumerable<ResearchTeam> SubsetWithResearchDurationTwoYears
        {
            get
            {
                return _researchTeams.Where(team => team.ResearchDuration == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            return _researchTeams
                .GroupBy(team => team.MembersList.Count)
                .Where(group => group.Key == value)
                .SelectMany(group => group)
                .ToList();
        }

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
        public event TeamListHandler? ResearchTeamAdded;
        public event TeamListHandler? ResearchTeamInserted;

        public void InsertAt(int j, ResearchTeam rt)
        {
            if (j >= 0 && j < _researchTeams.Count)
            {
                _researchTeams.Insert(j, rt);
                ResearchTeamInserted?.Invoke(this, new TeamListHandlerEventArgs(
                    CollectionName,
                    "Research team inserted",
                    j
                ));
            }
            else
            {
                Add(rt);
                ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(
                    CollectionName,
                    "Research team added",
                    _researchTeams.Count - 1
                ));
            }
               
        }

        public void Add(ResearchTeam rt)
        {
            _researchTeams.Add(rt);
            int index = _researchTeams.Count;

            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(
                CollectionName,
                "Research team added",
                index - 2
            ));
        }

        public ResearchTeam this[int index]
        {
            get
            {
                if (index >= 0 && index < _researchTeams.Count)
                    return _researchTeams[index];
                throw new ArgumentOutOfRangeException(nameof(index), "The index goes beyond the list");
            }
            set
            {
                if (index >= 0 && index < _researchTeams.Count)
                    _researchTeams[index] = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(index), "The index goes beyond the list");
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var researchTeam in _researchTeams)
            {
                result += researchTeam.ToString() + "\r\n";
            }

            return result;
        }

        public virtual string ToShortString()
        {
            string result = "";
            foreach (var researchTeam in _researchTeams)
            {
                result += researchTeam.ToShortString();
            }

            return result;
        }
    }
}
