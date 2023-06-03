using RESTWithASPDotNETCore.Model;

namespace RESTWithASPDotNETCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person CreatePerson(Person person)
        {
            return person;
        }

        public void DeletePerson(long id)
        {
            
        }

        public Person[] FindAllPeople()
        {
            Person[] people = new Person[10];
            for(int i = 0; i < people.Length; i++)
            {
                people[i] = MockPerson();
            }

            return people;
        }

        public Person FindPersonById(long id)
        {
            return MockPerson(id);
        }

        public Person UpdatePerson(Person person)
        {
            return person;
        }

        private Person MockPerson()
        {
            return MockPerson(0);
        }

        private Person MockPerson(long id)
        {
            return new Person
            {
                Id = id == 0 ? IncrementAndGet() : id,
                FirstName = "Daniel",
                LastName = "Orivaldo da Silva",
                Address = "Maringá - Paraná - Brazil",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
