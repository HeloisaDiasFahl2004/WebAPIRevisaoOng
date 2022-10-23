using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Service;

namespace WebAPIRevisãoOng.Controllers
{
    [Route("person/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly AddressService _addressService;
        private readonly PetService _petService;
        public PersonController(PersonService personService,AddressService addressService,PetService petService)
        {
            _personService = personService;
            _addressService = addressService;
            _petService = petService;
        }
        [HttpGet]
        public ActionResult<List<PersonModel>> Get() => _personService.Get();
        [HttpGet("{Id:length(24)}",Name ="GetOnePerson")]
        public ActionResult<PersonModel> GetOnePersonById(string id)
        {
            var person = _personService.GetOnePersonById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }
        [HttpPost]
        public ActionResult<PersonModel> PostPerson(PersonModel person)
        {
            AddressModel addressModel = _addressService.Create(person.Address);
            PetModel petModel = _petService.Create(person.Pet);
            person.Address = addressModel;
            person.Pet = petModel;  
            _personService.Create(person);
            return CreatedAtRoute("GetOnePerson", new {id=person.Id.ToString()},person);
        }
    }
}
