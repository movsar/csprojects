using ConsoleUtils;

public class Store
{
    internal string Name { get; set; }

    public Kitchen _kitchen;
    public Storage _storage;
    internal Store(string name)
    {
        Name = name;
        _storage = new Storage();
        _kitchen = new Kitchen(_storage);

    }

    public void Open()
    {
        try
        {
            Console.WriteLine("Добро пожаловать!");
            Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Менеджер" },
                { '2', "Клиент" }
            };
            char selectedOption = InputService.GetOption("Выберите дествие", options);
            switch (selectedOption)
            {
                case '1':
                    ShowManagerOptions();
                    break;

                case '2':
                    ShowClientOptions();
                    break;
                default:
                    Console.Clear();
                    Open();
                    return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.ReadKey();
            Console.Clear();
            Open();
        }
    }

    public void ShowClientOptions()
    {
        Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Показать список возможных тортов" },
                { '2', "Заказать торт" }
            };
        char selectedOption = InputService.GetOption("Выберите дествие", options);
        switch (selectedOption)
        {
            case '1':
                ShowAvailableCakeOptions();
                break;
            case '2':
                TakeOrder();
                break;
            default:
                Open();
                return;
        }

    }

    public void ShowManagerOptions()
    {
        Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Добавить ингредиенты" },
                { '2', "Показать список ингредиентов в наличии" }
            };
        char selectedOption = InputService.GetOption("Выберите дествие", options);
        switch (selectedOption)
        {
            case '1':
                AddIngredients();
                break;
            case '2':
                ShowIngredients();
                break;
            default:
                Open();
                return;
        }
    }

    public void AddIngredients()
    {
        Console.WriteLine("Введите ингредиенты в формате 'Название:Цена:Количество'");
        string? request = Console.ReadLine();
        string[] ingredientSeparately = request.Split(",");
        try
        {
            foreach (string ingredient in ingredientSeparately)
            {
                string[] partIngredients = ingredient.Split(":");
                Ingredient ingredients = new Ingredient()
                {
                    Name = partIngredients[0],
                    Cost = Convert.ToDecimal(partIngredients[1]),
                    Quantity = Convert.ToInt32(partIngredients[2]),
                };
                _storage.AddIngredient(ingredients);
            }
        }
        catch (Exception)
        {
            _storage.LoadIngredients();
        };
    }

    public Dictionary<string, Dictionary<string, int>> ShowAvailableCakeOptions()
    {
        Dictionary<string, Dictionary<string, int>> avaibleRecipes = _kitchen.GetAvailableRecipes();
        if (avaibleRecipes == null)
        {
            Console.WriteLine("Нет доступных рецептов");
        }
        Console.WriteLine(string.Join(",", avaibleRecipes));
        return avaibleRecipes;
    }

    public Cake TakeOrder()
    {
        Console.WriteLine("Напишите название торта который вы хотеть: ");
        string cake = Console.ReadLine();
        if (String.IsNullOrEmpty(cake))
            {
                Console.WriteLine("Вы не ввели название");
            }
            var newCake = _kitchen.MakeCake(cake);
            Console.WriteLine($"{newCake.Name} {newCake.Price}");
            return newCake;

    }

    public void ShowIngredients()
    {
        var ingredients = _storage.GetAllIngredients();
        Console.WriteLine("Ингридиенты на складе");
        Console.WriteLine("Название | Цена | Количество");
        foreach (var ingredient in ingredients)
        {
            Console.Write(ingredient.Name);
            Console.Write("|  ");
            Console.Write(ingredient.Cost);
            Console.Write("|  ");
            Console.Write(ingredient.Quantity);
            }
        Console.ReadKey();
        Console.Clear();
        Open();
    }

}