using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.DAL;
using WhatMeal.Model;

namespace WhatMeal.BL;

public class MealBL
{
    private readonly Random rand;

    public static MealBL Instance { get; set; } = new MealBL();

    public MealBL(Random random)
    {
        this.rand = random;
    }

    public MealBL() : this(new Random())
    {
    }

    public List<Dish> GetDish(bool? random, int? count, DishType? type)
    {
        random ??= true;
        count ??= 1;
        type ??= DishType.ALL;

        var dishes = JsonMealRepository.Instance.GetDishes();

        if (type != DishType.ALL)
        {
            dishes = dishes.Where(d => d.Type == type);
        }

        List<Dish> result;
        if (random.Value)
        {
            result = dishes.OrderBy(d => rand.Next()).Take(count.Value).ToList();
        }
        else
        {
            result = dishes.Take(count.Value).ToList();
        }

        return result;
    }
}
