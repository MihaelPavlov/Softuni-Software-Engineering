using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DefiningClasses
{
    public class Family
    {
        private readonly HashSet<Person> members;


        public Family()
        {
            this.members = new HashSet<Person>();
        }
        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = this.members.OrderByDescending(p => p.Age).FirstOrDefault();
           


            return oldestPerson;
        }
    }
}
