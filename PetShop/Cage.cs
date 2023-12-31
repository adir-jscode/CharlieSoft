using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Cage
    {
        public int Id { get; set; }
        public int CageNo { get; set; }
        public string? CageType { get; set; }
        public List<Pet> Pets { get; set; }
        public List<FeedingSchedule> Feedings { get; set; }
        
    }
}
