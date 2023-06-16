using Serilog;
using WhatMeal.BL;
using WhatMeal.Model;

namespace WhatMeal.API;

internal class DishEPMapper : IEPMapper
{
    private const string Tag = "Dish";

    public WebApplication Map(WebApplication app)
    {
        app.MapGet("dish", (bool? random, int? count, DishType? type) =>
        {
            var result = WhatMealBL.Dish.Get(random, count, type);
            Log.Logger.Information("Requested GET {count} dished of type {type}: found {length}", count, type, result.Count);
            return Results.Ok(result);
        }).WithTags(Tag).Produces<List<SingleDish>>(StatusCodes.Status200OK);

        app.MapPost("dish", (SingleDish dish) =>
        {
            WhatMealBL.Dish.InsertUpdate(dish);
            Log.Logger.Information("Dish '{name}' updated", dish.Name);
            return Results.Ok($"Dish '{dish.Name}' updated");
        }).WithTags(Tag).Produces(StatusCodes.Status200OK);

        app.MapDelete("dish", (string name) =>
        {
            var result = WhatMealBL.Dish.Delete(name);
            Log.Logger.Information("Requested DELETE of dish {name}, result is {result}", name, result);
            return result 
            ? Results.Ok($"Dish '{name}' deleted") 
            : Results.NotFound($"Dish '{name}' not found");
        }).WithTags(Tag).Produces(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
