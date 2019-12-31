using System;

namespace Comments.Problem.TooManyComments.Good
{
    public class Person
    {
        public string Name { get; }
        public DateTime Birthday { get; }
        // If objects can manage their own state without outside intervention- they should.
        // Person has enough info to calculate their own age.
        public int Age => (int)(DateTime.Now - Birthday).TotalDays / 365;
        public string Address { get; }

        public Person(string name, DateTime birthday, string address)
        {
            Name = name;
            Birthday = birthday;
            Address = address;
        }
    }
}
