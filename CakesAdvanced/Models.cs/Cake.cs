internal class Cake
{
    internal string Name { get; }
    internal decimal Price { get; private set; }

    internal List<Ingredient> _ingredients = new List<Ingredient>();

    internal Cake(string name, List<Ingredient> ingredients)
    {
        Name = name;
        _ingredients = ingredients;

        Price = _ingredients.Sum(i => (i.Cost * 0.5m) * i.Quantity);
    }
}