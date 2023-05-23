//using Presentations.View;
using Presentations.ViewModel;

namespace PresentationTests
{
    [TestClass]
    public class TestViewModel
    {

        [TestMethod]
        public void Title_PropertyChanged_RaisesEvent()
        {

            var addBook = new AddBook();
            bool eventRaised = false;
            addBook.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(addBook.Title))
                    eventRaised = true;
            };

            addBook.Title = "Sample Title";

            Assert.IsTrue(eventRaised, "PropertyChanged event not raised for Title property.");
        }

        [TestMethod]
        public void AddCommand_CanExecute_ReturnsTrue()
        {
            var addBook = new AddBook();

            bool canExecute = addBook.AddCommand.CanExecute(null);

            Assert.IsTrue(canExecute, "AddCommand.CanExecute returned false.");
        }

        [TestMethod]
        public void SetPropertyForBook()
        {
            // Arrange
            var addBook = new AddBook();

            // Act
            addBook.Title = "Title";
            addBook.Author = "Lukasz";
            addBook.Pages = 100;
            addBook.Id = "123";
            addBook.ISBN = "978-1234567890";
            addBook.Publisher = "Publisher";
            addBook.Language = "English";

            // Assert
            Assert.AreEqual("Title", addBook.Title);
            Assert.AreEqual("Lukasz", addBook.Author);
            Assert.AreEqual(100, addBook.Pages);
            Assert.AreEqual("123", addBook.Id);
            Assert.AreEqual("978-1234567890", addBook.ISBN);
            Assert.AreEqual("Publisher", addBook.Publisher);
            Assert.AreEqual("English", addBook.Language);
        }
    }
}