using ManagePeople.Business.ApiCallService;
using ManagePeople.Business.MappingProfiles;
using ManagePeople.Business.PersonService;
using ManagePeople.ViewModels.Person;
using Microsoft.AspNetCore.Mvc;

namespace ManagePeople.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoadPersons()
        {
            var response = await _personService.GetPersinList();
            var people = ObjectMapper.Mapper.Map<List<PersonViewModel>>(response);
            return Json(people);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int personId)
        {
            var person = await _personService.GetByCode(personId);
            return View(person);
        }
    }
}
