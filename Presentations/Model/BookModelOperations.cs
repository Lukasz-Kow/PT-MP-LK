﻿
using System.Collections.Generic;
using Services.API;

namespace Presentations.Model
{
    public class BookModelOperations
    {

        public BookModelOperations()
        {
            Services = IServices.Create("");
        }

        private IServices Services { get; set; }

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language)
        {
            Services.AddBook(Title, Author, Id, Pages, ISBN, Publisher, Language);
        }

        public void DeleteBook(string Id)
        {
            Services.DeleteBook(Id);
        }

        public List<BookModel> GetAllBooks()
        {
            var books = Services.GetAllBooks();
            var bookModels = new List<BookModel>();

            foreach (var book in books)
            {
                bookModels.Add(new BookModel(book.Title, book.Author, book.Id, book.Pages, book.ISBN, book.Publisher, book.Language));
            }

            return bookModels;
        }

    }
}