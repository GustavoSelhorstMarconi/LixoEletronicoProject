using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface IPersonRepository
    {
        Task UpdatePerson(int id, Person person);

        Task<Person> GetPerson(int id);
    }
}
