using System;

namespace Comments.Problem.Comments_Instead_of_SRP.Good
{
    public class Person
    {
        public string Name { get; }
        public DateTime Birthday { get; }
        // If objects can manage their own state without outside intervention- they should.
        // Person has enough info to calculate their own age.
        public int Age
        {
            get
            {
                // Includes leap years.
                const float averageYearDays = 365.25f;
                var ageInYears = (DateTime.Now - Birthday).TotalDays / averageYearDays;

                return (int)Math.Floor(ageInYears);
            }
        } 
        public string Address { get; }

        public Person(string name, DateTime birthday, string address)
        {
            Name = name;
            Birthday = birthday;
            Address = address;
        }
    }
}
