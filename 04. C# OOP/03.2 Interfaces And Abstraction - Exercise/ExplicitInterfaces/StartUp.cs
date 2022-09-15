using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                
                if (cmd == "End") break;

                string[] citizenData = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var citizen = new Citizen(citizenData[0], citizenData[1], int.Parse(citizenData[2]));

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
