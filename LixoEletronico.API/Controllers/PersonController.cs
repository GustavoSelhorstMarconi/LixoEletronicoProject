using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(PersonDto person)
        {
            await _personService.AddPerson(person);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, PersonDto person)
        {
            await _personService.UpdatePerson(id, person);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            PersonDto person = await _personService.GetPerson(id);

            return Ok(person);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeletePerson(id);

            return NoContent();
        }
    }
}