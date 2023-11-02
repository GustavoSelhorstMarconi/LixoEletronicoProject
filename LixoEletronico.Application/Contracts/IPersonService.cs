using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application.Contracts
{
    public interface IPersonService
    {
        Task AddPerson(Person person);

        Task UpdatePerson(int id, Person person);

        Task<Person> GetPerson(int id);

        Task DeletePerson(int id);
    }
}