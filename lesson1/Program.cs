using System;
using System.Collections.Generic;
using System.Linq;

// СУЩЕСТВИТЕЛЬНЫЕ / СУЩНОСТИ
public enum Genre
{
    futurism = 0,
    detective = 1,
    comedy = 2,
}

public class Book
{
    int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }
    public int Year { get; set; }
    public decimal Price  { get; set; }

    public Book(int id, string name, string author, Genre genre, int year, decimal price)
    {
        Id = id;
        Name = name;
        Author = author;
        Genre = genre;
        Year = year;
        Price = price;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private int nextId = 1;

    public void AddBook(string title, string  author, Genre genre, int year, decimal price)
    {
        var book = new Book(nextId++, title, author, genre, year, price);
        books.Add(book);
        Console.WriteLine($"\nКнига добавлена: {book}");
    }

    public void RemoveBook(int id)
    {
        var book = FindBookById(id);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"\nКнига с ID {id} удалена.");
        }
        else
        {
            Console.WriteLine($"\nКнига с ID {id} не найдена.");
        }
    }

    private Book FindBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public void FindBookById(string title)
    {
        var foundBooks = books.Where(b => b.Name.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplaySearchResults(foundBooks, $"по названию \"{title}\"");
    }

    public void FindBookByAuthor(string author)
    {
        var foundBooks = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplaySearchResults(foundBooks, $"по жанру \"{author}\"");
    }

    private void DisplaySearchResults(List<Book> foundBooks, string searchCriteria)
    {
        if (foundBooks.Any())
        {
            Console.WriteLine($"\nНайдено книг {searchCriteria}: {foundBooks.Count}");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine($"\nКниги {searchCriteria} не найдены.");
        }
    }

    public voidSortBookByName()
    {
        var sortedBooks = books.OrderBy(b => b.Name).ToList();
        DisplaySortedBooks(sortedBooks, "по названию");
    }

    public void SortBooksByYear()
    {
        var sortedBooks = books.OrderBy(b =>b.Year).ToList();
        DisplaySortedBooks(sortedBooks, "по году издания");
    }

    private void DisplaySortedBooks(List<Book> sortedBooks, string searchCriteria)
    {
        Console.WriteLine($"\nКниги отсортированы {sortCriteria}:");
        foreach (var book in sortedBooks)
        {
            Console.WriteLine(book);
        }
    }

    public void FindMostExpensiveAndCheapestBooks()
    {
        if (!books.Any())
        {
            Console.WriteLine("\nВ библиотеке нет книг.");
            return;
        }
        var mostExpensive = books.MaxBy(b => b.Price);
        DisplaySearchResults
    }
}