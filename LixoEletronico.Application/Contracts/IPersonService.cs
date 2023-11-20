using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Entities;

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