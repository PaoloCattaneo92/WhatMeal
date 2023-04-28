using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
