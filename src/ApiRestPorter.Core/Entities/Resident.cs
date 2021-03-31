using System;
namespace ApiRestPorter.Core.Entities
{
    public class Resident : BaseEntity
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Telephone { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public int ApartmentId { get; set; }

        public Apartment Apartment { get; set; }

    }
}
