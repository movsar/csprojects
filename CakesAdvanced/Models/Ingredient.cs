using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Ingredient
    {
        public string? Name { get; }
        public decimal Cost { get; }
        public int Quantity { get; set; }
    }
}
