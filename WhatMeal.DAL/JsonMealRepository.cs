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

    public IEnumerable<SingleDish> GetDishes()
    {
        return context.Get<SingleDish>();
    }

    public void InsertUpdateDish(SingleDish dish)
    {
        context.InsertUpdate(dish);
    }

    public bool DeleteDish(string name)
    {
        return context.Delete<SingleDish>(name);
    }
}
