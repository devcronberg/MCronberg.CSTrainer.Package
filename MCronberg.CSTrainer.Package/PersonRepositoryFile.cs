using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MCronberg
{
    public class PersonRepositoryFile : IPersonRepository
    {
        private readonly string file;
        public PersonRepositoryFile(string file)
        {
            this.file = file;
        }

        public void AddPerson(Person p)
        {
            List<Person> lst = GetPeople();
            lst.Add(p);
            Save(lst);
        }

        public void DeletePerson(int id)
        {
            try
            {
                List<Person> lst = Load();
                Person person = lst.Where(i => i.PersonId == id).First();
                lst.Remove(person);
                Save(lst);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting " + id, ex);
            }
        }

        public void Dispose()
        {

        }

        private List<Person> Load()
        {

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                using (StreamReader xml = new StreamReader(file))
                {
                    return (List<Person>)ser.Deserialize(xml);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error loading people from " + file, ex);
            }
        }

        private void Save(List<Person> lst)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                using (TextWriter writer = new StreamWriter(file))
                {
                    ser.Serialize(writer, lst);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing people", ex);
            }
        }

        public List<Person> GetPeople(int count = 200)
        {
            if (!System.IO.File.Exists(file))
            {
                return new List<Person>();
            }

            return Load();
        }

        public Person GetPerson(int id)
        {
            try
            {
                return GetPeople().Where(i => i.PersonId == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding " + id, ex);
            }
        }

        public void UpdatePerson(Person p)
        {
            try
            {
                List<Person> lst = Load();
                Person person = lst.Where(i => i.PersonId == p.PersonId).First();
                person.DateOfBirth = p.DateOfBirth;
                person.FirstName = p.FirstName;
                person.Gender = p.Gender;
                person.Height = p.Height;
                person.IsHealthy = p.IsHealthy;
                person.LastName = p.LastName;
                person.PersonId = p.PersonId;
                Save(lst);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating " + p.PersonId, ex);
            }
        }

        public static void CreateFileWithMockData(string file)
        {
            System.IO.File.Delete(file);
            IPersonRepository m = new PersonRepositoryMock();
            IPersonRepository f = new PersonRepositoryFile(file);
            foreach (Person item in m.GetPeople())
            {
                f.AddPerson(item);
            }
        }

        public static void CreateFileWithRandomData(string file)
        {
            System.IO.File.Delete(file);
            IPersonRepository m = new PersonRepositoryRandom();
            IPersonRepository f = new PersonRepositoryFile(file);
            foreach (Person item in m.GetPeople())
            {
                f.AddPerson(item);
            }
        }
    }
}