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
        const string ingredientsPATH = "ingredients.json";
        private List<Ingredient> _allingredients = new List<Ingredient>();

        public void SaveIngredients()
        {
            var serializedIngredients = JsonConvert.SerializeObject(_allingredients);
            File.WriteAllText(ingredientsPATH, serializedIngredients);
        }
        public void LoadIngredients()
        {
            if (File.Exists(ingredientsPATH))
            {
                var serializedIngredients = File.ReadAllText(ingredientsPATH);
                var deserializedIngredients = JsonConvert.DeserializeObject<Storage>(serializedIngredients);
                var deserializedInghredients = _allingredients;
                return;
            }
            throw new Exception("Такого файла не существует!");
        }
        public Storage (string ingredients)
        {
            LoadIngredients();
        }
        public Ingredient?  FindIngredientByName(string Name)
        {
            return _allingredients.Find(x => x.Name.ToLower() == Name.ToLower());
        }
        public Ingredient GetIngredientByName(string Name)
        {
            try
            {
                return _allingredients.First(x => x.Name.ToLower() == Name.ToLower());
            }
            catch
            {
                throw new Exception("Ингредиент не найден");
            }
        }
        public void AddIngredient(Ingredient ingredient)
        {
            var existingIngredient = FindIngredientByName(ingredient.Name);
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
        public void AddIngredients(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                AddIngredient(ingredient);
            }
        }
    }
}
