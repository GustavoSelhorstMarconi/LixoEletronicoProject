﻿using LixoEletronico.Application.Contracts;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public class PersonService : IPersonService
    {
        private readonly IGeneralRepository _repository;
        private readonly IPersonRepository _personRepository;

        public PersonService(IGeneralRepository repository, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task AddPerson(Person person)
        {
            await _repository.Add(person);
        }

        public async Task UpdatePerson(int id, Person person)
        {
            await _personRepository.UpdatePerson(id, person);
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _personRepository.GetPerson(id);
        }

        public async Task DeletePerson(int id)
        {
            Person person = await _personRepository.GetPerson(id);

            await _repository.Delete(person);
        }
    }
}
