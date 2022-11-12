﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int Comfort = 5;
        private const decimal Price = 10;

        public Plant() 
            : base(5, 10)
        {
        }
    }
}
