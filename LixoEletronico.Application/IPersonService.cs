using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public interface IPersonService
    {
        Task AddPerson(Person person);

        Task UpdatePerson(long id, Person person);

        Task<Person> GetPerson(long id);

        Task DeletePerson(long id);
    }
}