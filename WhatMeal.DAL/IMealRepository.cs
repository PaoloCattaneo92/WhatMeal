using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.Model;

namespace WhatMeal.DAL;

public interface IMealRepository
{
    IEnumerable<Dish> GetDishes();
    void InsertUpdateDish(Dish dish);
    bool DeleteDish(string name);
}