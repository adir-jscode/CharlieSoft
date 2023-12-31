using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Pet
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Color { get; set; }

        public int? Age { get; set; }

        public decimal Price { get; set; }

        public int CageId { get; set; }

        public Cage? Cage { get; set; }
        public List<SalePet> SalePet { get; set; }

    }
}
