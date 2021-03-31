using System.Collections.Generic;

namespace ApiRestPorter.Core.Entities
{
    public class Apartment : BaseEntity
    {   
        public int Number { get; set; }
        public string ApartmentBlock { get; set; }
        public IEnumerable<Resident> Residents { get; set; }
    }
}
