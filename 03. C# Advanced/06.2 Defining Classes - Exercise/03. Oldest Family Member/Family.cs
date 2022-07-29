using System.Collections.Generic;
using System.Linq;

namespace _03._Oldest_Family_Member
{
    public class Family
    {
        private List<Person> people = new List<Person>();

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person newMember)
        {
            people.Add(newMember);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = people.OrderByDescending(p => p.Age).First();
            return oldestMember;
        }
    }
}
