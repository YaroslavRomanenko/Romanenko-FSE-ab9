using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class TestCollections
    {
        List<Team> _teams;
        List<string> _teamsString;
        Dictionary<Team, ResearchTeam> _teamToResearchTeam;
        Dictionary<string, ResearchTeam> _stringToResearchTeam;

        public TestCollections(int size)
        {
            _teams = new List<Team>();
            _teamsString = new List<string>();
            _teamToResearchTeam = new Dictionary<Team, ResearchTeam>();
            _stringToResearchTeam = new Dictionary<string, ResearchTeam>();

            for (int i = 0; i < size; i++)
            {
                ResearchTeam researchTeam = GetRefResearchTeam(i);
                Team team = researchTeam.TeamInfo;

                _teams.Add(team);
                _teamsString.Add(team.ToShortString());
                _teamToResearchTeam[team] = researchTeam;
                _stringToResearchTeam[team.ToShortString()] = researchTeam;
            }
        }

        public static ResearchTeam GetRefResearchTeam(int index)
        {
            return new ResearchTeam($"Subject_{index}", $"Organization_{index}", index, TimeFrame.Long);
        }

        public void GetSearchTime()
        {
            Console.WriteLine("---- Measurement of search time ----");

            if (_teams.Count == 0)
            {
                Console.WriteLine("Collections are empty.");
                return;
            }

            Team firstTeam = _teams[0];
            string firstTeamString = _teamsString[0];
            Console.WriteLine("\n--- Search for the first item ---");
            SearchElement(firstTeam, firstTeamString);

            Team lastTeam = _teams[_teams.Count - 1];
            string lastTeamString = _teamsString[_teamsString.Count - 1];
            Console.WriteLine("\n--- Search for the last item ---");
            SearchElement(lastTeam, lastTeamString);

            int nonExistentIndex = _teams.Count + 1000;
            Team nonExistentTeam = new Team($"Organization_{nonExistentIndex}", nonExistentIndex);
            string nonExistentTeamString = nonExistentTeam.ToShortString();
            Console.WriteLine("\n--- Search for a non-existent item ---");
            SearchElement(nonExistentTeam, nonExistentTeamString);
        }

        private void SearchElement(Team searchTeam, string searchString)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool found;

            stopwatch.Restart();
            found = _teams.Contains(searchTeam);
            stopwatch.Stop();
            Console.WriteLine($"List<Team>: {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");

            stopwatch.Restart();
            found = _teamsString.Contains(searchString);
            stopwatch.Stop();
            Console.WriteLine($"List<string>: {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");

            stopwatch.Restart();
            found = _teamToResearchTeam.ContainsKey(searchTeam);
            stopwatch.Stop();
            Console.WriteLine($"Dictionary<Team, ResearchTeam> (key): {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");

            ResearchTeam searchResearchTeam = found ? _teamToResearchTeam[searchTeam] : GetRefResearchTeam(searchTeam.RegistrationID);
            stopwatch.Restart();
            found = _teamToResearchTeam.ContainsValue(searchResearchTeam);
            stopwatch.Stop();
            Console.WriteLine($"Dictionary<Team, ResearchTeam> (value): {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");

            stopwatch.Restart();
            found = _stringToResearchTeam.ContainsKey(searchString);
            stopwatch.Stop();
            Console.WriteLine($"Dictionary<string, ResearchTeam> (key): {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");

            stopwatch.Restart();
            found = _stringToResearchTeam.ContainsValue(searchResearchTeam);
            stopwatch.Stop();
            Console.WriteLine($"Dictionary<string, ResearchTeam> (value): {stopwatch.Elapsed.TotalMilliseconds:F6} ms, found: {found}");
        }
    }
}
