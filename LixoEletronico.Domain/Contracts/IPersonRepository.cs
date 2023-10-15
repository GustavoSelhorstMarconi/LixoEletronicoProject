using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface IPersonRepository
    {
        Task UpdatePerson(long id, Person person);

        Task<Person> GetPerson(long id);
    }
}
