using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static List<Team> teams = new List<Team>();

        static void Main()
        {

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END") break;

                string[] cmdArgs = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string mainArg = cmdArgs[0];

                if (mainArg == "Team")
                {
                    try
                    {
                        teams.Add(new Team(cmdArgs[1]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (mainArg == "Add")
                {                    
                    try
                    {
                        Team foundedTeam = LookForTeam(cmdArgs[1]);
                        Player newPlayer = new Player(cmdArgs[2], int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4]), int.Parse(cmdArgs[5]), int.Parse(cmdArgs[6]), int.Parse(cmdArgs[7]));
                        foundedTeam.AddPlayer(newPlayer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (mainArg == "Remove")
                {                    
                    try
                    {
                        Team foundedTeam = LookForTeam(cmdArgs[1]);
                        foundedTeam.RemovePlayer(cmdArgs[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (mainArg == "Rating")
                {                    
                    try
                    {
                        Team foundedTeam = LookForTeam(cmdArgs[1]);
                        Console.WriteLine($"{foundedTeam.TeamName} - {foundedTeam.Rating}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        static internal Team LookForTeam(string teamName)
        {
            Team foundedTeam = teams.FirstOrDefault(t => t.TeamName == teamName);

            if (foundedTeam == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

            return foundedTeam;
        }
    }
}
