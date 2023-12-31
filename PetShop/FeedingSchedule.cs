using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FeedingSchedule
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int CageId { get; set; }

        public Cage? Cage { get; set; }
    }
}
