using System;
using System.Collections.Generic;

namespace T06.MoneyTransactions
{
    class Program
    {
        static void Main()
        {
            string[] rawData = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            var bankAccounds = new Dictionary<int, double>();

            foreach (var data in rawData)
            {
                var tokens = data
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                bankAccounds.Add(int.Parse(tokens[0]), double.Parse(tokens[1]));
            }

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End") break;

                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string mainCmd = cmdArgs[0];

                    if (mainCmd != "Deposit" && mainCmd != "Withdraw")
                    {
                        throw new FormatException();
                    }

                    int currAccNum = int.Parse(cmdArgs[1]);
                    double currSum = double.Parse(cmdArgs[2]);

                    if (!bankAccounds.ContainsKey(currAccNum))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (mainCmd == "Deposit")
                    {
                        bankAccounds[currAccNum] += currSum;
                    }
                    else if (mainCmd == "Withdraw")
                    {
                        if (currSum > bankAccounds[currAccNum])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        bankAccounds[currAccNum] -= currSum;
                    }

                    Console.WriteLine($"Account {currAccNum} has new balance: {bankAccounds[currAccNum]:f2}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
