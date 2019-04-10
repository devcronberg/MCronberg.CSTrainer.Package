using System;

namespace MCronberg
{

    public static class PersonRepositoryFactory
    {
        public static IPersonRepository GetRepositoryFromTime()
        {
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                return new PersonRepositoryRandom();
            }
            else
            {
                return new PersonRepositoryMock();
            }
        }

        public static IPersonRepository GetRepositoryFromCompilation()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                return new PersonRepositoryRandom();
            }
            else
            {
                return new PersonRepositoryMock();
            }
        }

        public static IPersonRepository GetRepositoryFromString(string name = "RandomPeople.PersonRepositoryRandom")
        {
            try
            {
                Type t = Type.GetType(name);
                return (IPersonRepository)Activator.CreateInstance(t);

            }
            catch (Exception ex)
            {
                throw new Exception("Error creating repository", ex);
            }
        }

        // Needs reference to System.Configuration

        //public static IPersonRepository GetRepositoryFromConfiguration(string key = "PersonRepository")
        //{
        //    try
        //    {
        //        string name = System.Configuration.ConfigurationManager.AppSettings[key];
        //        return GetRepositoryFromString(name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error creating repository", ex);
        //    }
        //}


        public static IPersonRepository GetMockRepository()
        {
            return new PersonRepositoryMock();
        }

        public static IPersonRepository GetFileRepository(string file)
        {
            return new PersonRepositoryFile(file);
        }
        public static IPersonRepository GetRandomRepository()
        {
            return new PersonRepositoryRandom();
        }

    }
}