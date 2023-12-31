using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class PetPurchaseRecord
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public string SellerAddress { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string PetColor { get; set; }
        public int? PetAge { get; set; }
        public decimal PetPrice { get; set; }
    }
}
