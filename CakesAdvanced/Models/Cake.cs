using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
        public string Name { get; }
        public decimal Price { get; }
        public List<Ingredient> _ingredients { get; } = new List<Ingredient>();
        public Cake(string name, decimal price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            _ingredients = ingredients;
        }
    }
}