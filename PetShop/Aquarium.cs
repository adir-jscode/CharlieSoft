using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Aquarium
    {
        public int Id { get; set; }
        public int AquariumNumber { get; set; }
        public string AquariumType { get; set; }

        public List<Fish> Fish { get; set; }

        
    }
}
