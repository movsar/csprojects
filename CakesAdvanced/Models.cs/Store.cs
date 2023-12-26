internal class Store
{
    internal string Name { get; }

    private Kitchen _kitchen;
    private Storage _storage;
    internal Store(string name)
    {
        Name = name;
    }

}