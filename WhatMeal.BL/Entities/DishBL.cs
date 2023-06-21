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

        if (type.HasValue && type != DishType.ALL)
        {
            dishes = dishes.Where(d => d.Types.Contains(type.Value));
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

    public static List<Dish> GetRandom(int count, DishType type, IEnumerable<Dish> dishes)
    {
        var filtered = type != DishType.ALL
            ? dishes.Where(d => d.Types.Contains(type)).ToList()
            : dishes.ToList();

        var randomized = new List<Dish>();
        while (randomized.Count < count)
        {
            filtered = filtered.Where(d => !randomized.Any(d2 => d2.Name == d.Name)).ToList();
            if (filtered.Count == 0)
            {
                //throw new Exception($"No items found for type {type} after filter on {dishes.Count()} dishes");
                break;
            }

            var picked = filtered[Random.Shared.Next(0, filtered.Count)];
            randomized.Add(picked);
        }

        return randomized;
    }
}
