using System;
using System.Collections.Generic;

namespace MCronberg
{
    public class PersonRepositoryMock : IPersonRepository
    {

        public static List<Person> JustGetPeople(int count = 200)
        {
            return new PersonRepositoryMock().GetPeople(count);
        }

        public void AddPerson(Person p)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeople(int count = 200)
        {
            List<Person> p = new List<Person>();
            for (int i = 1; i <= count; i++)
            {
                p.Add(new Person() { PersonId = i, FirstName = "MockPerson", LastName = "#" + i, DateOfBirth = new DateTime(2019, 1, 1), Gender = Gender.Male, Height = 180, IsHealthy = true });
            }
            return p;
        }

        public Person GetPerson(int id)
        {
            return new Person() { PersonId = id, FirstName = "MockPerson", LastName = "#" + id, DateOfBirth = new DateTime(2019, 1, 1), Gender = Gender.Male, Height = 180, IsHealthy = true };
        }

        public void UpdatePerson(Person p)
        {
            throw new NotImplementedException();
        }
    }
}