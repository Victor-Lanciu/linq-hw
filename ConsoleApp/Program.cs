namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book { Id=1,Title="C# in Depth", Author = "John Skeet", Year = 2019, CopiesAvailable = 5 },
                new Book { Id=2,Title="Pro C#7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
                new Book { Id=3,Title="C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
                new Book { Id=4,Title="Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
                new Book { Id=5,Title="CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
            };
            var booksByAndreTroelsen = books.Where(b => b.Author == "Andrew Troelsen").ToList();
            Console.WriteLine("Books written by Andrew Troelsen:");
            foreach (var book in booksByAndreTroelsen)
            {
                Console.WriteLine($"Title: {book.Title}, Year: {book.Year}, CopiesAvailabe: {book.CopiesAvailable}");
            }

            var sortedBooksByYear = books.OrderByDescending(b => b.Year).ToList();
            Console.WriteLine("\nBooks published by year:");
            foreach (var book in sortedBooksByYear)
            {
                Console.WriteLine($"Title: {book.Title}, Author:{book.Author}, Year: {book.Year}, CopiesAvailabe: {book.CopiesAvailable}");
            }

            var availableBooks = books.Where(b => b.CopiesAvailable >= 1).Select(s => s.Title).ToList();
            Console.WriteLine("\nAvailable books:");
            foreach (var book in availableBooks)
            {
                Console.WriteLine(book);
            }

            var numberOfBooks = books.Sum(b => b.CopiesAvailable);
            Console.WriteLine($"\nTotal number of books: {numberOfBooks}");

            var distinctAuthors = books.Select(b => b.Author).Distinct().ToList();
            Console.WriteLine("\nList of authors:");
            foreach (var author in distinctAuthors)
            {
                Console.WriteLine(author);
            }

            var pageSize = 2;
            var pageNumber = 2;
            var paginatedBooks = books
                .OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            Console.WriteLine($"\nBooks from page {pageNumber}, sorted by title:");
            foreach (var book in paginatedBooks)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
