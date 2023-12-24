using System.Collections.Generic;

namespace CakesAdvanced.Models
{
    internal class Workshop
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
                {"Milk",  97},
                {"Sugar", 120},
                {"Flour", 100}
            };
            _recipes.Add("Medovik", Medovik);

            Dictionary<string, int> Napoleon = new Dictionary<string, int>()
            {
                { "Butter",  150},
                { "Eggs", 440},
                { "Salt", 75}
            };
            _recipes.Add("Napoleon", Napoleon);
        }
    }
}
