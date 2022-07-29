using System;

namespace _03._Oldest_Family_Member
{
    public class StartUp
    {
        static void Main()
        {
            int numOfPersons = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < numOfPersons; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var newPerson = new Person(name, age);

                family.AddMember(newPerson);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
