using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cmdCount = int.Parse(Console.ReadLine());

            var parkingLotRegister = new Dictionary<string, string>();

            for (int i = 0; i < cmdCount; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainCmd = cmdArgs[0];
                string userName = cmdArgs[1];

                if (mainCmd == "register")
                {
                    string licensePlateNum = cmdArgs[2];

                    if (parkingLotRegister.ContainsKey(userName))
                    {
                        string registeredPlateNum = parkingLotRegister
                            .Where(u => u.Key == userName).FirstOrDefault().Value;

                        Console.WriteLine($"ERROR: already registered with plate number {registeredPlateNum}");
                    }
                    else
                    {
                        parkingLotRegister.Add(userName, licensePlateNum);

                        Console.WriteLine($"{userName} registered {licensePlateNum} successfully");
                    }
                }
                else if (mainCmd == "unregister")
                {
                    if (parkingLotRegister.ContainsKey(userName))
                    {
                        parkingLotRegister.Remove(userName);

                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }

            foreach (var user in parkingLotRegister)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
