using WhatMeal.Model;

namespace WhatMeal.DAL;

public interface IMealRepository
{
    IEnumerable<SingleDish> GetDishes();
    void InsertUpdateDish(SingleDish dish);
    bool DeleteDish(string name);
}