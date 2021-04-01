using ApiRestPorter.Core.Entities;
using ApiRestPorter.Core.Interfaces;
using ApiRestPorter.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPorter.Web.Api
{
    public class ResidentController : BaseApiController
    {
        private readonly IResidentRepository _repository;

        public ResidentController(IResidentRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> List(int apartmentId)
        {
            var items = (await _repository.ListAsync(apartmentId)).Select(GetResidentDTO.FromResident);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _repository.GetByIdAsync(id);
            if (resident == null) return NotFound("Resident not found");

            return Ok(GetResidentDTO.FromResident(resident));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateResidentDTO body)
        {
            var resident = new Resident()
            {
                FullName = body.FullName,
                BirthDate = body.BirthDate,
                Cpf = body.Cpf,
                Email = body.Email,
                Telephone = body.Telephone,
                ApartmentId = body.ApartmentId,
            };
            await _repository.AddAsync(resident);
            return Ok(CreateResidentDTO.FromResident(resident));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resident = await _repository.GetByIdAsync<Resident>(id);
            if (resident == null) return NotFound("Resident not found");
            await _repository.DeleteAsync<Resident>(resident);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateResidentDTO putObject)
        {
            var resident = await _repository.GetByIdAsync<Resident>(id);
            if (resident == null) return NotFound("Resident not found");

            resident.FullName = putObject.FullName;
            resident.BirthDate = putObject.BirthDate;
            resident.Cpf = putObject.Cpf;
            resident.Email = putObject.Email;
            resident.Telephone = putObject.Telephone;
            resident.ApartmentId = putObject.ApartmentId;
            await _repository.UpdateAsync<Resident>(resident);
            return Ok();
        }
    }
}
