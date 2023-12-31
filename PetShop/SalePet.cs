using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class SalePet
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerAddress { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal SalePrice { get; set; }
        public int PetId { get; set; }

        public Pet? Pet { get; set; }
    }
}
