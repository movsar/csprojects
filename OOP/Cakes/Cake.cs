namespace Cakes
{
    internal class Cake
    {
        public string Title { get; }
        public string Ingredients { get; }
        public decimal Price { get; set; }
        public Cake(string title, string ingredients)
        {
            Title = title;
            Ingredients = ingredients;
        }
    }
}
