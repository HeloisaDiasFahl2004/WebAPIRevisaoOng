using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Service;

namespace WebAPIRevisãoOng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        //propriedade privada somente de leitura
        private readonly PetService _petService;

        //construtor
        public PetController(PetService petService)
        {
            _petService = petService;
        }
        #region Get
        //GetAll
        [HttpGet]
        public ActionResult<List<PetModel>> GetAllPets() => _petService.GetAllPet();
        //GetOne
        [HttpGet("{Chip:length(24)}",Name ="GetOnePet")]
        public ActionResult<PetModel> GetOnePetByChip(string chip)
        {
            var pet = _petService.GetOnePetByChip(chip);
            if(pet ==  null) return NotFound();//404

            return Ok(pet);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<PetModel> PostPet(PetModel pet)
        {
            _petService.Create(pet);
            return CreatedAtRoute("GetOnePet", new { chip = pet.Chip.ToString() }, pet);
        }
        #endregion

        //#region Put
        //[HttpPut]
        //public ActionResult<PetModel> Put(PetModel petIn, string chip)
        //{
        //    var pet = _petService.GetOnePetByChip(chip);
        //    if (pet == null) return NotFound();
        //    petIn.Chip = chip;
        //    _petService.Update(pet.Chip, petIn);
        //    return NoContent();
        //}
        //#endregion
    }
}
