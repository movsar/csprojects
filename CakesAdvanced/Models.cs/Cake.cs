internal class Cake
{
    internal string Name { get; }

    internal decimal Price { get; private set; }

    internal List<string> _ingredients = new List<string>();

    internal Cake(string name, List<string> ingredients)
    {
        Name = name;
        _ingredients = ingredients;

         Price = _ingredients.Sum(i => (i.Cost * 0.5m) * i.Quantity); 
    }
}