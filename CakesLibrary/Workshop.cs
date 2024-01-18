using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesLibrary.Models
{
    public class Workshop
    {
        Dictionary<string, Dictionary<string, int>> _recipes = new Dictionary<string, Dictionary<string, int>>();

        public Dictionary<string, Dictionary<string, int>> GetAllRecipes() 
        { 
            return _recipes;
        }

        public Workshop()
        {
            Dictionary<string, int> Medovik = new Dictionary<string, int>()
            {
                {"Мед", 3},
                {"Мука", 5},
                {"Сахар", 3},
                {"Масло", 2}
            };
            _recipes.Add("Медовик", Medovik);

            Dictionary<string, int> Napoleon = new Dictionary<string, int>()
            {
                {"Мука", 7},
                {"Масло", 4},
                {"Яйцо", 2},
                {"Сахар", 3}
            };
            _recipes.Add("Наполеон", Napoleon);
        }

        
    }
}
