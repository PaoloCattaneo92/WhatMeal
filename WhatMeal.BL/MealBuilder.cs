using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.Model;

namespace WhatMeal.BL;

public class MealBuilder
{
    private readonly Random random;

    public static MealBuilder Instance { get; set; } = new MealBuilder();

    public MealBuilder(Random random)
    {
        this.random = random;
    }

    public MealBuilder() : this(new Random())
    {
    }

    public Meal Build()
    {
        throw new NotImplementedException();
    }
}
