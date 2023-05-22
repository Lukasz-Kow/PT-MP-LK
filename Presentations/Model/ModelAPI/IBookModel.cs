
using System.Threading.Tasks;
using System.Web;

namespace Presentation.Model.ModelAPI
{
    public interface IBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }

        public int Pages { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public string Language { get; set; }
        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);

        public void DeleteBook(string Id);
    }
}
