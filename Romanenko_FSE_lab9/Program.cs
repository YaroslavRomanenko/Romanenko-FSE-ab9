namespace Romanenko_FSE_lab9
{
    class Program
    {
        static void Main()
        {
            ResearchTeamCollection firstResearchTeamCollection = new ResearchTeamCollection("firstResearchTeamCollection");
            ResearchTeamCollection secondResearchTeamCollection = new ResearchTeamCollection("secondResearchTeamCollection");

            // First researchTeam
            ResearchTeam firstResearchTeam = new ResearchTeam("Programming", "Simply name", 105, TimeFrame.TwoYears);

            Paper[] firstPubList = new Paper[]
            {
                new Paper("Mixtral of Experts", new Person(), new DateTime(2024, 1, 8)),
                new Paper("SuperStack: Superoptimization of Stack-Bytecode via Greedy, Constraint-Based, and SAT Techniques", new Person("Elvira", "Albert", new DateTime(1970, 8, 5)), new DateTime(2015, 5, 16)),
                new Paper("Inductive Approach to Spacer", new Person("Takeshi", "Tsukada", new DateTime(1982, 11, 15)), new DateTime(2019, 9, 5))
            };

            firstResearchTeam.AddPapers(firstPubList);

            Person[] firstMembers = new Person[]
            {
                new Person("Takeshi", "Tsukada", new DateTime(1982, 11, 15)),
                new Person("Tim", "Berners-Lee", new DateTime(1955, 6, 8)),
                new Person("Grace", "Hopper", new DateTime(1906, 12, 9))
            };

            firstResearchTeam.AddMembers(firstMembers);

            // Second researchTeam
            ResearchTeam secondResearchTeam = new ResearchTeam("Artificial Intelligence", "AI Labs", 548, TimeFrame.Year);

            Paper[] secondPubList = new Paper[]
            {
                new Paper("Generative Adversarial Networks", new Person("Ian", "Goodfellow", new DateTime(1985, 4, 8)), new DateTime(2014, 6, 10)),
                new Paper("Transformers: Attention is All You Need", new Person("Ashish", "Vaswani", new DateTime(1984, 3, 1)), new DateTime(2017, 6, 12))
            };

            secondResearchTeam.AddPapers(secondPubList);

            Person[] secondMembers = new Person[]
            {
                new Person("Ian", "Goodfellow", new DateTime(1985, 4, 8)),
                new Person("Geoffrey", "Hinton", new DateTime(1947, 12, 6)),
                new Person("Yann", "LeCun", new DateTime(1960, 7, 8))
            };

            secondResearchTeam.AddMembers(secondMembers);

            // Third researchTeam
            ResearchTeam thirdResearchTeam = new ResearchTeam("Quantum Computing", "QuantumTech", 111, TimeFrame.Long);

            Paper[] thirdPubList = new Paper[]
            {
                new Paper("Quantum Supremacy using a Programmable Superconducting Processor", new Person("John", "Martinis", new DateTime(1958, 2, 14)), new DateTime(2019, 10, 23)),
                new Paper("Shor's Algorithm: Breaking RSA Encryption", new Person("Peter", "Shor", new DateTime(1959, 8, 14)), new DateTime(1994, 11, 1))
            };

            thirdResearchTeam.AddPapers(thirdPubList);

            Person[] thirdMembers = new Person[]
            {
                new Person("John", "Martinis", new DateTime(1958, 2, 14)),
                new Person("Peter", "Shor", new DateTime(1959, 8, 14)),
            };

            firstResearchTeamCollection.AddResearchTeams(new ResearchTeam[]{ firstResearchTeam, secondResearchTeam });
            secondResearchTeamCollection.Add(thirdResearchTeam);

            TeamsJournal firstTeamJournal = new TeamsJournal();
            TeamsJournal secondTeamJournal = new TeamsJournal();

            firstResearchTeamCollection.ResearchTeamAdded += firstTeamJournal.OnTeamListChanged;
            firstResearchTeamCollection.ResearchTeamInserted += firstTeamJournal.OnTeamListChanged;

            firstResearchTeamCollection.ResearchTeamInserted += secondTeamJournal.OnTeamListChanged;
            secondResearchTeamCollection.ResearchTeamInserted += secondTeamJournal.OnTeamListChanged;

            ResearchTeam fourthResearchTeam = new ResearchTeam("Cybersecurity", "Cyber Defense", 951, TimeFrame.Year);

            // Add two new Research Team
            Paper[] fourthPubList = new Paper[]
            {
                new Paper("A Survey of Cybersecurity Threats", new Person("Bruce", "Schneier", new DateTime(1963, 1, 15)), new DateTime(2020, 3, 14)),
                new Paper("Zero Trust Security: The Future of Network Protection", new Person("John", "Kindervag", new DateTime(1970, 7, 21)), new DateTime(2018, 6, 25))
            };
            fourthResearchTeam.AddPapers(fourthPubList);

            Person[] fourthMembers = new Person[]
            {
                new Person("Bruce", "Schneier", new DateTime(1963, 1, 15)),
                new Person("John", "Kindervag", new DateTime(1970, 7, 21))
            };
            fourthResearchTeam.AddMembers(fourthMembers);

            ResearchTeam fifthResearchTeam = new ResearchTeam("Biotechnology", "BioTech Labs", 318, TimeFrame.TwoYears);

            Paper[] fifthPubList = new Paper[]
            {
                new Paper("CRISPR-Cas9: Gene Editing Revolution", new Person("Jennifer", "Doudna", new DateTime(1964, 2, 19)), new DateTime(2012, 8, 17)),
                new Paper("Synthetic Biology: Engineering Life", new Person("Drew", "Endy", new DateTime(1970, 4, 22)), new DateTime(2016, 5, 3))
            };
            fifthResearchTeam.AddPapers(fifthPubList);

            Person[] fifthMembers = new Person[]
            {
                new Person("Jennifer", "Doudna", new DateTime(1964, 2, 19)),
                new Person("Drew", "Endy", new DateTime(1970, 4, 22))
            };
            fifthResearchTeam.AddMembers(fifthMembers);

            firstResearchTeamCollection.Add(fourthResearchTeam);
            secondResearchTeamCollection.Add(fourthResearchTeam);

            firstResearchTeamCollection.InsertAt(5, fifthResearchTeam);
            secondResearchTeamCollection.InsertAt(1, fifthResearchTeam);

            Console.WriteLine("---- The First Team Journal ----");
            Console.WriteLine(firstTeamJournal);
            Console.WriteLine("---- The Second Team Journal ----");
            Console.WriteLine(secondTeamJournal);
        }
    }
}