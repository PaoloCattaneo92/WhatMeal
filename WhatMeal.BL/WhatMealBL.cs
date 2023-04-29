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
