using ConsoleUtils;

namespace Cakes
{
    internal class Program
    {
        const string PATH = @"CakesPrice.txt";
        static void Main(string[] args)
        {
            Start();
        }   
        static void Start()
        {
            string[] modes = { "1 - Выбор торта", "2 - Внести в прайс новый торт" };
            int? mode = InputService.SelectMode(modes);
                
            switch (mode)
            {
                case 1:
                    FindCake();
                    break;

                case 2:
                    AddCake();
                    break;
            }
        }

        static void FindCake()
        {
            Console.Clear();

            // Создаем переменную для списка всех тортов
            var allCakes = GetCakesFromFile();

            Console.WriteLine("Введите название торта: ");
            string? selectedName = Console.ReadLine();

            var foundCake = allCakes.Find(cake => cake.Title.ToLower() == selectedName.ToLower());
            if (foundCake == null)
            {
                Console.WriteLine("Нет такого торта");
                Console.ReadKey();
                FindCake();
            }
            else
            {
                Console.WriteLine($"{foundCake.Title}: {foundCake.Price}, ингридиенты = {foundCake.Ingredients}");
            }
        }
        private static void AddCake()
        {
            Console.Clear();
            Console.WriteLine("Введите данные о торте");

            Console.Write("Название: ");
            string? title = Console.ReadLine();

            Console.WriteLine("Ингредиенты: ");
            string? ingredients = Console.ReadLine();

            Console.WriteLine("Цена: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Cake newCake = new Cake(title, ingredients);
            newCake.Price = price;

            AddCakeToFile(newCake);

            Console.WriteLine("Данные о торте успешно добавлены в файл");
            Console.ReadKey();
            Start();
        }

        static void AddCakeToFile(Cake cake)
        {
            try
            {
                File.AppendAllText(PATH, $"{cake.Title} {cake.Ingredients} {cake.Price}\r\n");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Нет доступа к указанному пути");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла непонятная ошибка");
                throw;
            }
        }
        static List<Cake> GetCakesFromFile()
        {
            var allCakes = new List<Cake>();

            // Загружаем ранее сохраненные данные о тортах
            string[] fileEntries = File.ReadAllText(PATH).Split("\r\n");

            // Загружаем торты
            for (int i = 0; i < fileEntries.Length - 1; i++)
            {
                string[] data = fileEntries[i].Split(" ");

                string title = data[0];
                string ingredients = data[1];
                decimal price = Convert.ToDecimal(data[2]);

                // Создаем объект одного торта
                var cake = new Cake(title, ingredients);
                cake.Price = price;
                allCakes.Add(cake);
            }

            return allCakes;
        }
    }
}
