using LixoEletronico.Application;
using LixoEletronico.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost(Name = "AddPerson")]
        public async Task<ActionResult> Add(Person person)
        {
            await _personService.AddPerson(person);

            return NoContent();
        }

        [HttpPatch(Name = "UpdatePerson")]
        public async Task<ActionResult> Update(long id, Person person)
        {
            await _personService.UpdatePerson(id, person);

            return NoContent();
        }

        [HttpGet(Name = "GetPerson")]
        public async Task<ActionResult> Get(long id)
        {
            Person person = await _personService.GetPerson(id);

            return Ok(person);
        }

        [HttpDelete(Name = "DeletePerson")]
        public async Task<ActionResult> Delete(long id)
        {
            await _personService.DeletePerson(id);

            return NoContent();
        }
    }
}