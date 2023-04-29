using WhatMeal.Model;

namespace WhatMeal.DAL;

public interface IMealRepository
{
    IEnumerable<Dish> GetDishes();
    void InsertUpdateDish(Dish dish);
    bool DeleteDish(string name);
}