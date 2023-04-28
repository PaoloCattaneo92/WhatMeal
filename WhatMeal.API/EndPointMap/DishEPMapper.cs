﻿using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using WhatMeal.BL;
using WhatMeal.DAL;
using WhatMeal.Model;

namespace WhatMeal.API;

internal class DishEPMapper : IEPMapper
{
    private const string Tag = "Dish";

    public WebApplication Map(WebApplication app)
    {
        app.MapGet("dish", (bool? random, int? count, DishType? type) =>
        {
            var result = MealBL.Instance.GetDish(random, count, type);
            Log.Logger.Information("Requested GET {count} dished of type {type}: found {length}", count, type, result.Count);
            return Results.Ok(result);
        }).WithTags(Tag).Produces<List<Dish>>(StatusCodes.Status200OK);

        app.MapPost("dish", (Dish dish) =>
        {
            JsonMealRepository.Instance.InsertUpdateDish(dish);
            Log.Logger.Information("Dish '{name}' updated", dish.Name);
            return Results.Ok($"Dish '{dish.Name}' updated");
        }).WithTags(Tag).Produces(StatusCodes.Status200OK);

        app.MapDelete("dish", (string name) =>
        {
            var result = JsonMealRepository.Instance.DeleteDish(name);
            Log.Logger.Information("Requested DELETE of dish {name}, result is {result}", name, result);
            return result 
            ? Results.Ok($"Dish '{name}' deleted") 
            : Results.NotFound($"Dish '{name}' not found");
        }).WithTags(Tag).Produces(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
