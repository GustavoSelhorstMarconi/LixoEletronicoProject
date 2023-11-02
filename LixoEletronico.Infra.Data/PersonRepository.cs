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

        public async Task UpdatePerson(int id, Person person)
        {
            Person? personToUpdate = await _context.People
                .SingleOrDefaultAsync(x => x.Id == id);

            if (personToUpdate == null)
            {
                throw new ApplicationException("Pessoa não encontrada.");
            }

            personToUpdate.UpdatePerson(person);

            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            Person? person = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                throw new ApplicationException("Pessoa não encontrada.");
            }

            return person;
        }
    }
}
