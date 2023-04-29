using JsonDb;
using WhatMeal.Model;

namespace WhatMeal.DAL;

public class JsonMealRepository : IMealRepository
{
    public static JsonMealRepository Instance { get; set; } = new JsonMealRepository("data");

    private readonly JsonContext context;

    public JsonMealRepository(string dataFolder)
    {
        context = new JsonContext(dataFolder);
    }

    public IEnumerable<Dish> GetDishes()
    {
        return context.Get<Dish>();
    }

    public void InsertUpdateDish(Dish dish)
    {
        context.InsertUpdate(dish);
    }

    public bool DeleteDish(string name)
    {
        return context.Delete<Dish>(name);
    }
}
