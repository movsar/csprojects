using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CakesAdvanced.Models
{
    internal class Storage
    {
        const string PATH = "ingredients.json";
        private List<Ingredient> _allIngredients;

        public void SaveIngredients()
        {
            var serializedIngredients = JsonConvert.SerializeObject(_allIngredients);
            File.WriteAllText(PATH, serializedIngredients);
        }
        public void LoadIngredients()
        {
            if(File.Exists(PATH))
            {
                var serializedIngredients = File.ReadAllText(PATH);
                var deserializedIngredients = JsonConvert.DeserializeObject<List<Ingredient>>(PATH);
                if(deserializedIngredients != null)
                {
                    _allIngredients= deserializedIngredients;
                }
            }
            throw new Exception("Такого файла не существует!");
        }
        public Storage(string ingredients)
        {
            LoadIngredients();
        }
        public Ingredient? FindIngredientByName(string nameOfIngredient)
        {
            return _allIngredients.Find(i => i.Name.ToLower() == nameOfIngredient.ToLower());
        }
        public Ingredient GetIngredientByName(string nameOfIngredient)
        {
            return _allIngredients.First(someWord =>someWord.Name.ToLower() == nameOfIngredient.ToLower());
        }
        public void AddIngredients(Ingredient ingredient)
        {
            var existingIngredient = FindIngredientByName(ingredient.Name);
            if(existingIngredient != null)
            {
                existingIngredient.Quantity += ingredient.Quantity;
            }
            else
            {
                _allIngredients.Add(ingredient);
            }
            SaveIngredients();
        }
        public void AddIngredient(List<Ingredient> ingredients)
        {
            foreach(var ingredient in ingredients)
            {
                AddIngredients(ingredient);
            }
        }
    }
}
