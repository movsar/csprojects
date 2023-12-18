using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CakesAdvanced.Models
{
    internal class Storage
    {
        private List<Ingredient> _allingredients = new List<Ingredient>();

        public void SaveIngredients()
        {

        }

        public void LoadIngredients()
        {

        }

        public Storage()
        {
            LoadIngredients();
        }

        public Ingredient? FindIngredientByName(string Name)
        {
            return _allingredients.Find(x => x.Name.ToLower() == Name.ToLower());
        }

        public Ingredient GetIngredientByName(string Name)
        {
            return _allingredients.First(x => x.Name.ToLower() == Name.ToLower());  
        }

        public void AddIngredient(Ingredient ingredient)
        {

        }

        public void AddIngredients(List<Ingredient> ingredients)
        {

        }
    }
}
