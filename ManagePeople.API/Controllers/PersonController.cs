using ManagePeople.Data.DataModels.Person;
using ManagePeople.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManagePeople.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<List<Person>> GetPeople()
        {
            return await _repository.GetPersons();
        }

        [HttpGet("{personCode}")]
        public async Task<Person> GetPerasonById([FromRoute] int personCode)
        {
            return await _repository.GetPersonByCode(personCode);
        }
    }
}
