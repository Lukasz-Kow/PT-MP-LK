

using Services.API;
using System.Collections.Generic;
using Presentations.Model.Implementation;

namespace Presentations.Model.API
{
    interface IBookModelOperations
    {
        static IBookModelOperations CreateModelOperation()
        {
            return new BookModelOperations();
        }

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);
        public void DeleteBook(string Id);
        public IEnumerable<IBookModel> GetAllBooks();
    }
}
