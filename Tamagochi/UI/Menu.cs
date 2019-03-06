using System.Collections.Generic;
using Tamagochi.Core.Consumables;

namespace Tamagochi.UI
{
    public static class Menu
    {
        public static Dictionary<string, Meal> meals = new Dictionary<string, Meal>
        {
            ["Яблоко"] = new Meal(1, 3, 0),
            ["Дошик"] = new Meal(-1, 6, 0),
            ["Каша"] = new Meal(4, -1, 0),
            ["Булка"] = new Meal(1, 1, 0)
        };

        public static Dictionary<string, Amusement> amusements = new Dictionary<string, Amusement>
        {
            ["Датка"] = new Amusement(-2, 8, -6),
            ["Прогулка"] = new Amusement(-1, 3, -1),
            ["Зомбоящик"] = new Amusement(-2, 4, -2),
            ["Аутирование"] = new Amusement(-1, 2, 0)
        };
    }
}