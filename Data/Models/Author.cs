using System;
using Data.Models;

namespace TodoApi.Data.Models{
    public class Author
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    //navigation properties
    //many to many realtionship btwn book and author, thus book_authpr will have one to many relationship between author and book_authior similarly for book; 
    // Thus Book_Author will joijn both book and author;
    public List<Book_Author> Book_Authors { get; set; }
}

}
