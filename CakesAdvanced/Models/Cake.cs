using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
        private string Name;
        private decimal Price;
        public List<Ingredient> _ingredients { get; } = new List<Ingredient>();
        public Cake(string name, decimal price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            _ingredients = ingredients;
        }
    }
}