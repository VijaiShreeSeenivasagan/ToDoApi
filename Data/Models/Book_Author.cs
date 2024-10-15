using System;
using Data.Models;

namespace TodoApi.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        //navigation properties
        public required int BookId { get; set; }
        public Book Book { get; set; }
        public required int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}