using System.Collections;

namespace Romanenko_FSE_lab9
{
    internal class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        private string _researchSubjects;
        private TimeFrame _researchDuration;
        private List<Person> _membersList;
        private List<Paper> _publicationList;

        public ResearchTeam() : this("None", "None", 0, TimeFrame.None) { }

        public ResearchTeam(string researchSubjects, string organizationName, int registrationID, TimeFrame researchDuration)
            : base(organizationName, registrationID)
        {
            _researchSubjects = researchSubjects;
            _researchDuration = researchDuration;
            _membersList = new List<Person>();
            _publicationList = new List<Paper>();
        }

        public string ResearchSubjects { get { return _researchSubjects; } set { _researchSubjects = value; } }
        public TimeFrame ResearchDuration { get { return _researchDuration; } set { _researchDuration = value; } }
        public List<Paper> PublicationList { get { return _publicationList; } set { _publicationList = value; } }
        public List<Person> MembersList { get { return _membersList; } set { _membersList = value; } }

        public bool this[TimeFrame index]
        {
            get { return _researchDuration == index; }
        }

        public Paper? GetRefOnLatePub
        {
            get
            {
                if (_publicationList is null || _publicationList.Count == 0)
                {
                    return null;
                }

                return _publicationList.Cast<Paper>().OrderByDescending(p => p.PublicationDate).First();
            }
        }

        public Team TeamInfo
        {
            get
            {
                return new Team(_organizationName, _registrationID);
            }
            set
            {
                _organizationName = value.Name;
                _registrationID = value.RegistrationID;
            }
        }

        public void AddPapers(Paper[] papers)
        {
            if (papers is not null)
            {
                foreach (var paper in papers)
                {
                    _publicationList.Add(paper);
                }
            }
        }

        public void AddMembers(Person[] members)
        {
            if (members is not null)
            {
                foreach (var member in members)
                {
                    _membersList.Add(member);
                }
            }
        }

        public IEnumerable<Person> GetMembersWithMoreThanOnePublication()
        {
            foreach (Person member in _membersList)
            {
                int publicationCount = _publicationList.Cast<Paper>().Count(p => p.PublicationAuthor == member);

                if (publicationCount > 1)
                {
                    yield return member;
                }
            }
        }

        public IEnumerable<Person> GetMembersWithoutPublications()
        {
            foreach (Person member in _membersList)
            {
                if (!_publicationList.Cast<Paper>().Any(p => p.PublicationAuthor.Equals(member)))
                {
                    yield return member;
                }
            }
        }

        public IEnumerable<Paper> GetRecentPub(int amount)
        {
            DateTime nYearsAgo = DateTime.Now.AddYears(-amount);
            foreach (Paper paper in _publicationList)
            {
                if (paper.PublicationDate >= nYearsAgo)
                {
                    yield return paper;
                }
            }
        }

        private class ResearchTeamEnumerator : IEnumerator
        {
            private ResearchTeam team;
            private int currentIndex;

            public ResearchTeamEnumerator(ResearchTeam team)
            {
                this.team = team;
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                currentIndex++;

                while (currentIndex < team._membersList.Count)
                {
                    var member = team._membersList[currentIndex] as Person;
                    if (member is not null && team._publicationList.Cast<Paper>().Any(p => p.PublicationAuthor == member))
                    {
                        return true;
                    }
                    currentIndex++;
                }
                return false;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public object? Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= team._membersList.Count)
                        throw new InvalidOperationException();
                    return team._membersList[currentIndex];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ResearchTeamEnumerator(this);
        }

        public int Compare(ResearchTeam? left, ResearchTeam? right)
        {
            return string.Compare(left.ResearchSubjects, right.ResearchSubjects);
        }

        public override string ToString()
        {
            string result;
            result = $"---- Research Team ----\nResearch Subjects: {_researchSubjects}\nOrganization Name: {_organizationName}\nRegistration Number: {_registrationID}\nResearch Duration: {_researchDuration}" + " ";

            if (_membersList.Count != 0)
            {
                result += "\n--- Members ---";
                foreach (Person person in _membersList.OfType<Person>())
                {
                    result += person.ToString();
                }
            }

            if (_publicationList.Count != 0)
            {
                foreach (Paper paper in _publicationList.OfType<Paper>())
                {
                    result += "\n--- Publication ---" + paper.ToString();
                }
            }

            return result + "\n";
        }

        public override string ToShortString()
        {
            return $"{_researchSubjects} {_organizationName} {_registrationID.ToString()} {_researchDuration.ToString()}";
        }

        public override object DeepCopy()
        {
            ResearchTeam researchTeam = new ResearchTeam(_researchSubjects, _organizationName, _registrationID, _researchDuration);

            researchTeam.PublicationList = _publicationList;
            researchTeam.MembersList = _membersList;

            return researchTeam;
        }
    }
}
