public class Store
{
    internal string Name { get; set; }

    private Kitchen _kitchen;
    private Storage _storage;
    internal Store(string name)
    {
        Name = name;
        _storage = new Storage();
    }

    public void AddIngredients()
    {
        Console.WriteLine("Введите ингредиенты в формате 'Название:Цена:Количество'");
        string? request = Console.ReadLine();
        string[] ingredientSeparately = request.Split(',');
        foreach (string ingredient in ingredientSeparately)
        {
            string[] partIngredients = ingredient.Split(':');
            Ingredient ingredients = new Ingredient();
            {

            }
        }
    }

}