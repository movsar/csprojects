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
        const string INGREDIENTS_PATH = "ingredients.json";
        private List<Ingredient> _allingredients = new List<Ingredient>();

        public void SaveIngredients()
        {
            var serializationIngredients = JsonConvert.SerializeObject(_allingredients);
            File.WriteAllText(INGREDIENTS_PATH, serializationIngredients);
        }

        public void LoadIngredients()
        {
            if (File.Exists(INGREDIENTS_PATH))
            {
                var serializationIngredients = File.ReadAllText(INGREDIENTS_PATH);
                _allingredients = JsonConvert.DeserializeObject<List<Ingredient>>(serializationIngredients);
                return;
            }
            else
            {
                throw new Exception("Файл не найден!");
            }
        }
        public Storage()
        {
            LoadIngredients();
        }

        public Ingredient? FindIngredientByName(string Name)
        {
            try
            {
                return _allingredients.Find(x => x.Name.ToLower() == Name.ToLower());
            }
            catch
            {
                throw new Exception("Ингредиент не найден");
            }
        }

        public Ingredient GetIngredientByName(string Name)
        {
            return _allingredients.First(x => x.Name.ToLower() == Name.ToLower());
        }

        public void AddIngredient(Ingredient ingredient)
        {
            var existingIngredient = FindIngredientByName(ingredient.Name);
            {
                if (existingIngredient != null)
                {
                    existingIngredient.Quantity += ingredient.Quantity;
                }
                else
                {
                    _allingredients.Add(ingredient);
                }
                SaveIngredients();
            }
        }

        public void AddIngredients(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                AddIngredient(ingredient);
            }
        }
    }
}