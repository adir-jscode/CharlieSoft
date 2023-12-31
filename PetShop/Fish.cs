﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Fish
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public int AquariumId { get; set; }
        public Aquarium? Aquarium { get; set; }
    }
}
