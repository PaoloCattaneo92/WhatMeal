using WhatMeal.Model;

namespace WhatMeal.BL;

public class WhatMealBL
{
    public static DishBL Dish { get; set; } = new DishBL();

    public static Day RandomizeDay(List<Dish>? dishes = null)
    {
        dishes ??= Dish.GetAll();

        var forCarbo = DishTypeHelp.For(ElementType.CARBO);
        var forProtein = DishTypeHelp.For(ElementType.PROTEIN);
        var forVeggie = DishTypeHelp.For(ElementType.VEGETABLES);
        var lunch = new Meal(
                Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forCarbo), dishes).First(),
                Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forProtein), dishes).First(),
                Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forVeggie), dishes).First()
                );
        var dinner = new Meal(
            Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forCarbo), dishes).First(),
            Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forProtein), dishes).First(),
            Dish.GetRandom(1, Random.Shared.NextFromIEnumerable(forVeggie), dishes).First()
            );
        var day = new Day(lunch, dinner);
        return day;
    }

    public static Week RandomizeWeek(List<Dish>? dishes = null)
    {
        dishes ??= Dish.GetAll();
        var week = new Week();
        for (int i = 0; i < 7; i++)
        {
            week.Days[i] = RandomizeDay(dishes);
        }
        return week;
    }
}
