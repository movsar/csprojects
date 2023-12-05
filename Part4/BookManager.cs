namespace movsar_part4
{
    public enum Genre
    {
        Fiction,
        NonFiction,
        ScienceFiction,
        Novel,
        Detective,
        Horror
    }
    public class Book
    {
        public Genre Genre { get; }
        public int Pages { get; }
        public string Title { get; } = string.Empty;
        public Book(string title, int pagesCount, Genre genre)
        {
            Title = title;
            Pages = pagesCount;
            Genre = genre;
        }
    }

    public class BookShelf
    {
        List<Book> Books { get; } = new List<Book>();
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Добавили книгу {book.Title}");
        }
    }

    internal class BookManager
    {
        public static void Start()
        {
            BookShelf bookShelf = new BookShelf();
            Book book1 = new Book("The subtle art of not giving a f*ck", 206, Genre.NonFiction);
            bookShelf.AddBook(book1);
        }
    }

}
