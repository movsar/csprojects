using ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Store
    {
        public string Name { get; }
        private Kitchen _kitchen;
        private Storage _storage;
        public Store(string name)
        {
            Name = name;
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
        }

        public void AddIngredients()
        {
             Console.WriteLine("Введите ингредиенты в формате 'Название:Цена:Количество");
             string input = Console.ReadLine();
             string[] ingredientsSeparately = input.Split(',');
            try
            {
                foreach (string x in ingredientsSeparately)
                {
                    string[] ingredientsDetails = x.Split(':');
                    Ingredient ingredients = new Ingredient()
                    {
                        Name = ingredientsDetails[0],
                        Cost = Convert.ToDecimal(ingredientsDetails[1]),
                        Quantity = Convert.ToInt32(ingredientsDetails[2])
                    };
                    _storage.AddIngredients(ingredients);
                }
            }
            catch (Exception)
            {
                _storage.LoadIngredients();
            }
        }

        public void ShowManageOptions()
        {
            string[] modes = { "1. Добавить ингредиенты" };
            int? mode = InputService.GetOption(modes);

            if(mode==1)
            {
                AddIngredients();
            }  
        } 
        public void ShowClientOption()
        {
            string[] modes = { "1.Показать список возможных тортов", "2.Заказать торт" };
            int? mode = InputService.GetOption(modes);
            Console.Clear();

            if (mode == 1)
            {
                ShowAvailableCakeOptions();
            }
            if(mode == 2)
            {
                TakeOrder();
            }
        }

        public void ShowAvailableCakeOptions()
        {
            var availableRecipes = _kitchen.GetAvailableRecipes();
            if (availableRecipes==null)
            {
                Console.WriteLine("Доступных рецептов нет");
            }
            else
            {
                Console.WriteLine($"Доступные рецепты: ", availableRecipes);
            }
        }

        public void TakeOrder()
        {
            Console.WriteLine("Пожалуйста, напишите название нужного торта");
            string input = Console.ReadLine();
            if (input == null)
            {
                throw new Exception("Вы не ввели название");
            }
            try
            {
                var newCake = _kitchen.MakeCake(input);
                Console.WriteLine($"Ваш торт {newCake.Name} готов! Вот его цена: { newCake.Price}");
            }
            catch (Exception)
            {
                throw new Exception("Торт не удалось сделать");
            }
        }

        public void Open()
        {
           
            string[] modes = { "Менеджер", "Клиент" };
            int? mode = InputService.GetOption(modes);
            switch(mode)
            {
                case 1:
                    ShowManageOptions(); 
                    break;
                case 2:
                    ShowClientOption();
                    break;
            }
            Open();
        }
    }
}
