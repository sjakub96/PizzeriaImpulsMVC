﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Drink
{
    public class ListDrinkForListVm
    {
        public List<DrinkForListVm>? Drinks { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string FilterString { get; set; }

        public int Count { get; set; }

    }
}
