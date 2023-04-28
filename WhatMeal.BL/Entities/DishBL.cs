using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.DAL;
using WhatMeal.Model;

namespace WhatMeal.BL;

public class DishBL
{
    public void InsertUpdate(Dish dish)
    {
        if (dish == null)
        {
            return;
        }

        //TODO add validation and field normalization

        JsonMealRepository.Instance.InsertUpdateDish(dish);
    }

    public bool Delete(string name)
    {
        if (name == null)
        {
            return false;
        }

        return JsonMealRepository.Instance.DeleteDish(name);
    }

    public List<Dish> GetAll()
    {
        return JsonMealRepository.Instance.GetDishes().ToList();
    }

    public List<Dish> Get(bool? random, int? count, DishType? type)
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
            result = dishes.OrderBy(d => Random.Shared.Next()).Take(count.Value).ToList();
        }
        else
        {
            result = dishes.Take(count.Value).ToList();
        }

        return result;
    }
}
