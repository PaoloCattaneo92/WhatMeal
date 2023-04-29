using WhatMeal.DAL;

namespace WhatMeal.Test;

internal class UTWithDAL
{
    protected readonly JsonMealRepository repository;

    public UTWithDAL()
    {
        repository = new JsonMealRepository(Environment.DATA_FOLDER);
    }
}
