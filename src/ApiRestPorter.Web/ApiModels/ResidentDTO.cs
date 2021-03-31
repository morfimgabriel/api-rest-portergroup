using ApiRestPorter.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiRestPorter.Web.ApiModels
{
    public class ResidentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cpf { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ApartmentId { get; set; }

        public ApartmentDTO Apartment { get; set; }


        public static ResidentDTO FromResident(Resident item)
        {
            return new ResidentDTO()
            {
                Id = item.Id,
                FullName = item.FullName,
                BirthDate = item.BirthDate,
                Telephone = item.Telephone,
                Cpf = item.Cpf,
                Email = item.Email,
                ApartmentId = item.ApartmentId,
                Apartment = ApartmentDTO.FromApartment(item.Apartment)

            };
        }

    }
}
