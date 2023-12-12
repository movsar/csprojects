using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
      public string Name {  get; set; }
      public decimal Price {  get; set; }
      public List<string> _ingredients { get; }=new List<string>();

        public Cake(string name, List<string> ingredients) 
        {
            Name = name;
            _ingredients = ingredients;
        }
    }
}
