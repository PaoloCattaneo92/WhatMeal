using WhatMeal.Model;

namespace WhatMeal.BL;

public class WhatMealBL
{
    public static DishBL Dish { get; set; } = new DishBL();

    private static readonly IEnumerable<DishType> FOR_CARBO =  DishTypeHelp.For(ElementType.CARBO);
    private static readonly IEnumerable<DishType> FOR_PROTEIN = DishTypeHelp.For(ElementType.PROTEIN);
    private static readonly IEnumerable<DishType> FOR_VEGETABLES = DishTypeHelp.For(ElementType.VEGETABLES);

    public static Day RandomizeDay(List<Dish>? dishes = null, IEnumerable<Dish>? exludeDishes = null)
    {
        dishes ??= Dish.GetAll();

        var lunch = RandomizeMeal(dishes, exludeDishes);
        var dinner = RandomizeMeal(dishes, exludeDishes);

        var day = new Day(lunch, dinner);
        return day;
    }

    private static Meal RandomizeMeal(List<Dish> dishes, IEnumerable<Dish> exludeDishes)
    {
        var mealDishes = new List<Dish>
        {
            DishBL.GetRandom(1, Random.Shared.NextFromIEnumerable(FOR_CARBO), dishes).First()
        };
        if (!mealDishes.IsCompleteMeal())
        {
            mealDishes.Add(DishBL.GetRandom(1, Random.Shared.NextFromIEnumerable(FOR_PROTEIN), dishes, ElementType.CARBO, exludeDishes).First());
        }
        if (!mealDishes.IsCompleteMeal())
        {
            mealDishes.Add(DishBL.GetRandom(1, Random.Shared.NextFromIEnumerable(FOR_VEGETABLES), dishes, ElementType.CARBO, exludeDishes).First());
        }

        return new Meal(mealDishes);
    }

    public static Week RandomizeWeekAdvanced(List<Dish>? dishes = null)
    {
        dishes ??= Dish.GetAll();

        // 2-3 red meal
        var redMeatDishes = DishBL.GetRandom(Random.Shared.Next(2, 4), DishType.MEAT_RED, dishes);
        // 2-4 fish
        var fishDishes = DishBL.GetRandom(Random.Shared.Next(2, 5), DishType.FISH, dishes);




        //for (int i = 0; i < 7; i++)
        //{
        //    week.Days[i] = RandomizeDay(dishes, week.Days.Where(d => d != null).SelectMany(d => d.AllDishes));
        //}
        //return week;
        return null;
    }

    public static Week RandomizeWeek(List<Dish>? dishes = null)
    {
        dishes ??= Dish.GetAll();
        var week = new Week();
        for (int i = 0; i < 7; i++)
        {
            week.Days[i] = RandomizeDay(dishes, week.Days.Where(d => d != null).SelectMany(d => d.AllDishes));
        }
        return week;
    }

    public static WeekRandomizeResult RandomizeWeek(List<Dish>? dishes = null, List<WeekValidationRule>? rules = null, int? maxTries = null)
    {
        maxTries ??= 10000;
        Week? week = null;
        int tries = 0;
        var failures = new Dictionary<string, WeekValidationRuleFail>();
        
        if(rules != null)
        {
            foreach(var rule in rules)
            {
                failures.Add(rule.Description, new WeekValidationRuleFail(rule.Description));
            }
        }

        while (tries < maxTries)
        {
            week = RandomizeWeek(dishes);
            tries++;
            if (rules == null)
            {
                break;
            }

            var failed = rules.Where(r => !r.Validate(week)).ToList();
            if (failed.Count == 0)
            {
                break;
            }
            
            foreach (var fail in failed)
            {
                if (failures.TryGetValue(fail.Description, out WeekValidationRuleFail? value) && value != null)
                {
                    failures[value.Description].Increment();
                }
            }
            week = null;
        }

        return new WeekRandomizeResult(week != null, week, tries, failures.Values.ToList());
    }
}
