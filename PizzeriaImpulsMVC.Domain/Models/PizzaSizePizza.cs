﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class PizzaSizePizza
    {
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
        public int PizzaSizeId { get; set; }
        public PizzaSize? PizzaSize { get; set; }

        
    }
}
