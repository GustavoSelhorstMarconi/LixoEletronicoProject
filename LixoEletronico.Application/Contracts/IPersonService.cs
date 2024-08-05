using LixoEletronico.Shared.Dtos;

namespace LixoEletronico.Application.Contracts
{
    public interface IPersonService
    {
        Task AddPerson(PersonDto person);

        Task UpdatePerson(int id, PersonDto person);

        Task<PersonDto> GetPerson(int id);

        Task DeletePerson(int id);
    }
}