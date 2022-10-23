using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Service;

namespace WebAPIRevisãoOng.Controllers
{
    [Route("address[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
 
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        #region Get
        [HttpGet("{cep}")]
        public ActionResult<string> GetAddress(string cep)
        {
            var address = _addressService.GetAddress(cep);
            if (address == null) return NotFound();
            return Ok(address);
        }
        [HttpGet]
        public ActionResult<List<AddressModel>> GetAll() => _addressService.GetAll();
        
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<AddressModel> PostAddress(AddressModel address)
        {
            _addressService.Create(address);
            return CreatedAtRoute(new { idAddress = address.IdAddress.ToString() }, address );
        }
        #endregion
    }
}
