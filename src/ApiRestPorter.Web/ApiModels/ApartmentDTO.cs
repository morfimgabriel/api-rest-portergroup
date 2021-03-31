using ApiRestPorter.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPorter.Web.ApiModels
{
    public class ApartmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo Obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ApartmentBlock { get; set; }

        public static ApartmentDTO FromApartment(Apartment item)
        {
            return new ApartmentDTO()
            {
                Id = item.Id,
                Number = item.Number,
                ApartmentBlock = item.ApartmentBlock
            };
        }

    }
}
