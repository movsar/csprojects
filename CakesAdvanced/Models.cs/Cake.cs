internal class Cake
{
    public string Name { get; }

    public decimal Price { get; private set; }

    public List<string> _ingredients = new List<string>();

    public Cake(string name, List<string> ingredients)
    {
        Name = name;
        _ingredients = ingredients;     
    }


}