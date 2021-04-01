using ApiRestPorter.Core.Entities;
using System;
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

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }
    }

    public class CreateResidentDTO : ResidentDTO
    {
        [Range(1, 1000, ErrorMessage = "Número maior que 0 obrigatório")]
        public int ApartmentId { get; set; }

        public static CreateResidentDTO FromResident(Resident item)
        {
            return new CreateResidentDTO()
            {
                Id = item.Id,
                FullName = item.FullName,
                BirthDate = item.BirthDate,
                Telephone = item.Telephone,
                Cpf = item.Cpf,
                Email = item.Email,
                ApartmentId = item.ApartmentId
            };
        }
    }

    public class GetResidentDTO : ResidentDTO
    {
        public ApartmentDTO Apartment { get; set; }

        public static GetResidentDTO FromResident(Resident item)
        {
            return new GetResidentDTO()
            {
                Id = item.Id,
                FullName = item.FullName,
                BirthDate = item.BirthDate,
                Telephone = item.Telephone,
                Cpf = item.Cpf,
                Email = item.Email,
                Apartment = ApartmentDTO.FromApartment(item.Apartment)
            };
        }
    }

    public class UpdateResidentDTO
    {
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

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Range(1, 1000, ErrorMessage = "Número maior que 0 obrigatório")]
        public int ApartmentId { get; set; }

    }
}
