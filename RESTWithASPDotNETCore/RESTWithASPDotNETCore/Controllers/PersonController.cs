using Microsoft.AspNetCore.Mvc;
using RESTWithASPDotNETCore.Model;
using RESTWithASPDotNETCore.Services.Implementations;

namespace RESTWithASPDotNETCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAllPeople());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            if (Util.Util.IsNumeric(id))
            {
                Person person = _personService.FindPersonById(Util.Util.ConvertToLong(id));
                return Ok(person);
            }
            return BadRequest();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Person person) {
            if(person == null) return BadRequest();
            return Ok(_personService.CreatePerson(person));
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.UpdatePerson(person));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (Util.Util.IsNumeric(id))
            {
                long personId = Util.Util.ConvertToLong(id);
                _personService.DeletePerson(personId);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
