using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 1; i <= teamsCount; i++)
            {
                string[] teamDetails = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                string creator = teamDetails[0];
                string teamName = teamDetails[1];
                Team newTeam = new Team(creator, teamName);
                bool isNewTeamOrCreator = true;

                foreach (Team team in teams)
                {
                    if (team.TeamName == newTeam.TeamName)
                    {
                        isNewTeamOrCreator = false;
                        Console.WriteLine($"Team {newTeam.TeamName} was already created!");
                        break;
                    }
                }

                if (isNewTeamOrCreator)
                {
                    foreach (Team team in teams)
                    {
                        if (team.Creator == newTeam.Creator)
                        {
                            isNewTeamOrCreator = false;
                            Console.WriteLine($"{newTeam.Creator} cannot create another team!");
                            break;
                        }
                    }
                }

                if (isNewTeamOrCreator)
                {
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string assignment = Console.ReadLine();
            while (assignment != "end of assignment")
            {
                string[] assignmentDetails = assignment
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                string newMember = assignmentDetails[0];
                string teamToJoin = assignmentDetails[1];

                bool isTeamExist = false;

                foreach (Team currTeam in teams)
                {
                    if (currTeam.TeamName == teamToJoin)
                    {
                        isTeamExist = true;
                        bool isMemberExist = false;

                        foreach (Team otherTeam in teams)
                        {
                            if (otherTeam.Members.Contains(newMember)
                                || newMember == otherTeam.Creator)
                            {
                                isMemberExist = true;
                                Console.WriteLine
                                    ($"Member {newMember} cannot join team {teamToJoin}!");
                                break;
                            }
                        }

                        if (!isMemberExist)
                        {
                            currTeam.Members.Add(newMember);
                        }
                    }
                }

                if (!isTeamExist)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }

                assignment = Console.ReadLine();
            }

            teams = teams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            List<string> disband = new List<string>();

            foreach (Team currTeam in teams)
            {
                if (currTeam.Members.Count > 0)
                {
                    Console.WriteLine(currTeam.TeamName);
                    Console.WriteLine($"- {currTeam.Creator}");
                    foreach (string member in currTeam.Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
                else
                {
                    disband.Add(currTeam.TeamName);
                }
            }

            disband = disband.OrderBy(x => x).ToList();

            Console.WriteLine("Teams to disband:");
            Console.WriteLine(string.Join(Environment.NewLine, disband));
        }
    }

    class Team
    {
        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.TeamName = teamName;
            this.Members = new List<string>();
        }

        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<string> Members { get; set; }
    }
}
