using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
