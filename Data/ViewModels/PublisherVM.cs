using System.ComponentModel.DataAnnotations;

namespace TodoApi.Data.ViewModels
{
    public class PublisherVM
    {
        public required string Name { get; set; }

    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public required string Name { get; set; }

        public required List<BookAuthorVM> BooksAndAuthors { get; set; }
    }

     public class BookAuthorVM
    {
        public required string BookName { get; set; }

        public required List<string> BookAndAuthors { get; set; }

    }
}