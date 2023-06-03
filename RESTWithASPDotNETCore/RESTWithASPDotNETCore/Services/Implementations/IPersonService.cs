using RESTWithASPDotNETCore.Model;

namespace RESTWithASPDotNETCore.Services.Implementations
{
    public interface IPersonService
    {
        Person CreatePerson(Person person);
        Person FindPersonById(long id);
        Person UpdatePerson(Person person);
        void DeletePerson(long id);
        Person[] FindAllPeople();
    }
}
