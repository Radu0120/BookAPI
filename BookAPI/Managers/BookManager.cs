using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using BookAPI.Controllers;

namespace BookAPI.Managers
{
    public class BookManager
    {
        public IEnumerable<Book> GetAll()
        {
            return BookController.BooksCatalog.Values;
        }
        public Book GetBook(string isbn13)
        {
            return BookController.BooksCatalog[isbn13];
        }
        public void Create(Book book)
        {
            BookController.BooksCatalog.Add(book.ISBN13, book);
        }
        public void Update(string isbn13, Book book)
        {
            BookController.BooksCatalog[isbn13].Author = book.Author;
            BookController.BooksCatalog[isbn13].PageNumber = book.PageNumber;
            BookController.BooksCatalog[isbn13].Title = book.Title;
        }
        public void Delete(string isbn13)
        {
            BookController.BooksCatalog.Remove(isbn13);
        }
    }
}
