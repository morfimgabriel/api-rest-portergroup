using ApiRestPorter.Core.Entities;
using ApiRestPorter.Core.Interfaces;
using ApiRestPorter.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPorter.Web.Api
{
    public class ApartmentController : BaseApiController
    {
        private readonly IApartmentRepository _repository;

        public ApartmentController(IApartmentRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = (await _repository.ListAsync<Apartment>()).Select(ApartmentDTO.FromApartment);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var apartment = await _repository.GetByIdAsync<Apartment>(id);
            if (apartment == null) return NotFound("Apartment not found");

            return Ok(ApartmentDTO.FromApartment(apartment));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApartmentDTO body)
        {
            var apartment = new Apartment()
            {
                ApartmentBlock = body.ApartmentBlock,
                Number = body.Number
            };
            await _repository.AddAsync(apartment);
            return Ok(ApartmentDTO.FromApartment(apartment));
        }
    }
}
