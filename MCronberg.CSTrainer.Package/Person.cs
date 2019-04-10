using System;

namespace MCronberg
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name => FirstName + " " + LastName;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public bool IsHealthy { get; set; }
        public Gender Gender { get; set; }

    }
}