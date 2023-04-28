﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.DAL;
using WhatMeal.Model;

namespace WhatMeal.BL;

public class WhatMealBL
{
    private readonly Random rand;

    public static DishBL Dish { get; set; } = new DishBL();

    public WhatMealBL(Random random)
    {
        this.rand = random;
    }

    public WhatMealBL() : this(new Random())
    {
    }
}