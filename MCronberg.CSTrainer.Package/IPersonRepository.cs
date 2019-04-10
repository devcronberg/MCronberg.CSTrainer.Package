using System;
using System.Collections.Generic;

namespace MCronberg
{
    public interface IPersonRepository : IDisposable
    {
        void AddPerson(Person p);
        void DeletePerson(int id);
        List<Person> GetPeople(int count = 200);
        Person GetPerson(int id);
        void UpdatePerson(Person p);
    }
}