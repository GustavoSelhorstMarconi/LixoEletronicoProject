using AutoMapper;
using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public class PersonService : IPersonService
    {
        private readonly IGeneralRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IGeneralRepository repository, IPersonRepository personRepository, IMapper mapper)
        {
            _repository = repository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task AddPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            await _repository.Add(person);
        }
        
        public async Task UpdatePerson(int id, PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            await _personRepository.UpdatePerson(id, person);
        }

        public async Task<PersonDto> GetPerson(int id)
        {
            var person = await _personRepository.GetPerson(id);

            var result = _mapper.Map<PersonDto>(person);

            return result;
        }

        public async Task DeletePerson(int id)
        {
            Person person = await _personRepository.GetPerson(id);

            await _repository.Delete(person);
        }
    }
}
