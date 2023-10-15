using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LixoEletronico.Infra.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context)
        {
            _context = context;
        }

        public async Task UpdatePerson(long id, Person person)
        {
            Person? personToUpdate = await GetPerson(id);

            personToUpdate.UpdateEntity(person);

            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPerson(long id)
        {
            Person? person = await _context.People.SingleOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                throw new ApplicationException("Pessoa não encontrada.");
            }

            return person;
        }
    }
}
